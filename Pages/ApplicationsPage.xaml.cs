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

namespace GazLink
{
    /// <summary>
    /// Логика взаимодействия для ApplicationsPage.xaml
    /// </summary>
    public partial class ApplicationsPage : Page
    {
        public ApplicationsPage()
        {
            InitializeComponent();
            LVApplications.ItemsSource = context.Applications.ToList().OrderBy(i => i.idApplication);
            List<Status> status = context.Status.ToList();
            status.Insert(0, new Status() { Title = "Все" });
            cmbFiltr.ItemsSource = status;
            cmbFiltr.DisplayMemberPath = "Title";
            cmbFiltr.SelectedIndex = 0;

            cmbSort.ItemsSource = new List<String>//Передаем в комбобокс лист со значениями
            {
                "По умолчанию",
                "ФИО (по возрастанию)",
                "ФИО (по убыванию)",
                "Дата создания (по возрастанию)",
                "Дата создания (по убыванию)",
                "Дата установки (по возрастанию)",
                "Дата установки (по убыванию)",
                "Сумма (по возрастанию)",
                "Сумма (по убыванию)"
            };
            cmbSort.SelectedIndex = 0;//Выбираем индекс по умолчанию
        }

        public void Filter()
        {
            var list = context.Applications.Where(i => i.Client.FirstName.Contains(tbSearch.Text) || i.Client.LastName.Contains(tbSearch.Text) || i.Client.MiddleName.Contains(tbSearch.Text)).ToList();
            if (dpDate.SelectedDate.HasValue)
            {
                list = list.Where(i => i.DateOfCreation == dpDate.SelectedDate.Value || i.DateOfCompletion == dpDate.SelectedDate.Value).ToList();
            }


            if (cmbFiltr.SelectedIndex == 0)
            {
                LVApplications.ItemsSource = list;
            }
            else
            {
                var status = cmbFiltr.SelectedItem as Status;
                list = list.Where(i => i.Status == status).ToList();
            }

            switch (cmbSort.SelectedIndex)
            {
                case 1:
                    list = list.OrderBy(i => i.Client.FIO).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.Client.FIO).ToList();
                    break;
                case 3:
                    list = list.OrderBy(i => i.DateOfCreation).ToList();
                    break;
                case 4:
                    list = list.OrderByDescending(i => i.DateOfCreation).ToList();
                    break;
                case 5:
                    list = list.OrderBy(i => i.DateOfCompletion).ToList();
                    break;
                case 6:
                    list = list.OrderByDescending(i => i.DateOfCompletion).ToList();
                    break;
                case 7:
                    list = list.OrderBy(i => i.TotalPrice).ToList();
                    break;
                case 8:
                    list = list.OrderByDescending(i => i.TotalPrice).ToList();
                    break;
                default:
                    break;
            }

            LVApplications.ItemsSource = list;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Clear();
            cmbFiltr.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            dpDate.SelectedDate = null;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }


        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            if (LVApplications.SelectedItem is Applications applications)
            {
                idApp = applications.idApplication;
                InfoAboutApplicationWindow infoApp = new InfoAboutApplicationWindow();
                infoApp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите заявку из списка!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            Filter();
        }
    }
}
