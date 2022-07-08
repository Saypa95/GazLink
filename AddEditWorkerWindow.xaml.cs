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
    /// Логика взаимодействия для AddEditWorkerWindow.xaml
    /// </summary>
    public partial class AddEditWorkerWindow : Window
    {
        public AddEditWorkerWindow()
        {
            InitializeComponent();
            cmbGender.ItemsSource = context.Gender.Select(i => i.Gender1).ToList();
            cmbAccess.ItemsSource = context.Access.Select(i => i.AccessLevel).ToList();
            if (checkEdit)
            {
                tbLastName.Text = workr.LastName;
                tbFirstName.Text = workr.FirstName;
                tbMiddleName.Text = workr.MiddleName;
                cmbGender.SelectedItem = context.Gender.Where(i => i.idGender == workr.idGender).Select(i => i.Gender1).FirstOrDefault();
                cmbAccess.SelectedItem = context.Access.Where(i => i.idAccess == workr.idAccess).Select(i => i.AccessLevel).FirstOrDefault();
                tbLogin.Text = workr.Login;
                tbPassword.Text = workr.Password;
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
            if (tbLastName.Text.Length > 0 && tbFirstName.Text.Length > 0 && tbMiddleName.Text.Length > 0 
                && tbLogin.Text.Length > 0 && tbPassword.Text.Length > 0 && cmbAccess.SelectedItem != null && cmbGender.SelectedItem != null)
            {
                if (checkEdit)
                {
                    workr.LastName = tbLastName.Text;
                    workr.FirstName = tbFirstName.Text;
                    workr.MiddleName = tbMiddleName.Text;
                    workr.Login = tbLogin.Text;
                    workr.Password = tbPassword.Text;
                    workr.idGender = context.Gender.Where(i => i.Gender1 == cmbGender.SelectedItem.ToString()).Select(i => i.idGender).FirstOrDefault();
                    workr.idAccess = context.Access.Where(i => i.AccessLevel == cmbAccess.SelectedItem.ToString()).Select(i => i.idAccess).FirstOrDefault();
                    context.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    checkEdit = false;
                }
                else
                {
                    context.Worker.Add(new Worker
                    {
                        LastName = tbLastName.Text,
                        FirstName = tbFirstName.Text,
                        MiddleName = tbMiddleName.Text,
                        idGender = context.Gender.Where(i => i.Gender1 == cmbGender.SelectedItem.ToString()).Select(i => i.idGender).FirstOrDefault(),
                        idAccess = context.Access.Where(i => i.AccessLevel == cmbAccess.SelectedItem.ToString()).Select(i => i.idAccess).FirstOrDefault(),
                        Login = tbLogin.Text,
                        Password = tbPassword.Text
                    });
                    context.SaveChanges();
                    MessageBox.Show("Сотрудник успешно добавлен!",
                    "Добавление товара", MessageBoxButton.OK, MessageBoxImage.Information);
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
            var result = MessageBox.Show("Вы действительно хотите удалить сотрудника?",
                   "Удаление сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                context.Worker.Remove(context.Worker.Where(i => i.idWorker == workr.idWorker).FirstOrDefault());
                context.SaveChanges();
                MessageBox.Show("Запись успешно удалена", "Удаление cотрудника", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.Close();
        }
    }
}
