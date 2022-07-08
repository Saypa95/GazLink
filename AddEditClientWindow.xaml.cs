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
using System.Windows.Shapes;
using static GazLink.Classes.AppData;

namespace GazLink
{
    /// <summary>
    /// Логика взаимодействия для AddEditClientWindow.xaml
    /// </summary>
    public partial class AddEditClientWindow : Window
    {
        public AddEditClientWindow()
        {
            InitializeComponent();
            cmbGender.ItemsSource = context.Gender.Select(i => i.Gender1).ToList();
            if (checkEdit)
            {
                tbLastName.Text = client.LastName;
                tbFirstName.Text = client.FirstName;
                tbMiddleName.Text = client.MiddleName;
                tbPhone.Text = client.Phone;
                tbEmail.Text = client.Email;
                cmbGender.SelectedItem = context.Gender.Where(i => i.idGender == client.idGender).Select(i => i.Gender1).FirstOrDefault();
                tbAddress.Text = client.Address;
            }
            else
            {
                btnDelete.Visibility = Visibility.Collapsed;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            checkEdit = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbLastName.Text.Length > 0 && tbFirstName.Text.Length > 0 && tbAddress.Text.Length > 0 
                && tbEmail.Text.Length > 0 && tbPhone.Text.Length > 0 && cmbGender.SelectedItem != null)
            {
                if (checkEdit)
                {
                    client.LastName = tbLastName.Text;
                    client.FirstName = tbFirstName.Text;
                    client.MiddleName = tbMiddleName.Text;
                    client.Address = tbAddress.Text;
                    client.Phone = tbPhone.Text;
                    client.Email = tbEmail.Text;
                    client.idGender = context.Gender.Where(i => i.Gender1 == cmbGender.SelectedItem.ToString()).Select(i => i.idGender).FirstOrDefault();
                    context.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    checkEdit = false;
                }
                else
                {
                    context.Client.Add(new Client
                    {
                        LastName = tbLastName.Text,
                        FirstName = tbFirstName.Text,
                        MiddleName = tbMiddleName.Text,
                        Address = tbAddress.Text,
                        Phone = tbPhone.Text,
                        Email = tbEmail.Text,
                        idGender = context.Gender.Where(i => i.Gender1 == cmbGender.SelectedItem.ToString()).Select(i => i.idGender).FirstOrDefault()
                    });
                    context.SaveChanges();
                    MessageBox.Show("Клиент успешно добавлен!",
                    "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    checkEdit = false;
                }
            }
            else
            {
                MessageBox.Show("Заполните все обязательные поля!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (context.Applications.Where(i => i.idClient == client.idClient).FirstOrDefault() != null)
            {
                MessageBox.Show("Имеются заявки с данным клиентом, удаление запрещено!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var result = MessageBox.Show("Вы действительно хотите удалить клиента?",
                       "Удаление клиента", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    context.Client.Remove(context.Client.Where(i => i.idClient == client.idClient).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Удаление клиента", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                this.Close();
            }
        }
    }
}
