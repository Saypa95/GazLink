using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static GazLink.Classes.AppData;

namespace GazLink.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            LVClient.ItemsSource = context.Client.ToList().OrderBy(i => i.idClient);

            List<Gender> gender = context.Gender.ToList();
            gender.Insert(0, new Gender() { Gender1 = "Все" });
            cmbGender.ItemsSource = gender;
            cmbGender.DisplayMemberPath = "Gender1";
            cmbGender.SelectedIndex = 0;

            cmbSort.ItemsSource = new List<String>
            {
                "По умолчанию",
                "Фамилия (от А до Я)",
                "Фамилия (от Я до А)",
                "Имя (от А до Я)",
                "Имя (от Я до А)",
                "Отчество (от А до Я)",
                "Отчество (от Я до А)",
            };
            cmbSort.SelectedIndex = 0;
        }

        public void Filter()
        {
            var list = context.Client.Where(i => i.FirstName.Contains(tbSearch.Text) || i.LastName.Contains(tbSearch.Text) || i.MiddleName.Contains(tbSearch.Text) 
            || i.Address.Contains(tbSearch.Text) || i.Phone.Contains(tbSearch.Text) || i.Email.Contains(tbSearch.Text)).ToList();

            if (cmbGender.SelectedIndex == 0)
            {
                LVClient.ItemsSource = list;
            }
            else
            {
                var gender = cmbGender.SelectedItem as Gender;
                list = list.Where(i => i.idGender == gender.idGender).ToList();
                LVClient.ItemsSource = list;
            }

            switch (cmbSort.SelectedIndex)
            {
                case 1:
                    list = list.OrderBy(i => i.LastName).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.LastName).ToList();
                    break;
                case 3:
                    list = list.OrderBy(i => i.FirstName).ToList();
                    break;
                case 4:
                    list = list.OrderByDescending(i => i.FirstName).ToList();
                    break;
                case 5:
                    list = list.OrderBy(i => i.MiddleName).ToList();
                    break;
                case 6:
                    list = list.OrderByDescending(i => i.MiddleName).ToList();
                    break;
                default:
                    break;
            }

            LVClient.ItemsSource = list;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Clear();
            cmbGender.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddEditClientWindow addEditClient = new AddEditClientWindow();
            addEditClient.ShowDialog();
            Filter();
        }

        private void btnEditClient_Click(object sender, RoutedEventArgs e)
        {
            if (LVClient.SelectedItem is Client clnt)
            {
                client = clnt;
                checkEdit = true;
                AddEditClientWindow addEditClient = new AddEditClientWindow();
                addEditClient.ShowDialog();
                Filter();
            }
            else
            {
                MessageBox.Show("Выберите клиента из списка!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            Filter();
        }
    }
}
