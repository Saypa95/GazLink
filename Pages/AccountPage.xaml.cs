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
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
            tbLastName.Text = workerLogIn.LastName;
            tbFirstName.Text = workerLogIn.FirstName;
            tbMiddleName.Text = workerLogIn.MiddleName;
            tblLogin.Text = workerLogIn.Login;
            tblPassword.Text = workerLogIn.Password;
            tbLogin.Text = workerLogIn.Login;
            tbPassword.Text = workerLogIn.Password;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text.Length > 0 && tbPassword.Text.Length > 0)
            {
                var worker = context.Worker.Where(i => i.idWorker == workerLogIn.idWorker).FirstOrDefault();
                worker.Login = tbLogin.Text;
                worker.Password = tbPassword.Text;
                context.SaveChanges();
                MessageBox.Show("Изменения успешно сохранены!", "Изменение логина/пароля!", MessageBoxButton.OK, MessageBoxImage.Information);
                tblLogin.Text = workerLogIn.Login;
                tblPassword.Text = workerLogIn.Password;
            }
            else
            {
                MessageBox.Show("Поля Логин и Пароль обязательны к заполнению!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
