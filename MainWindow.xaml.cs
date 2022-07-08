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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text.Length > 0 && pbPassword.Password.Length > 0)
            {
                workerLogIn = context.Worker.Where(i => i.Login == tbLogin.Text && i.Password == pbPassword.Password).FirstOrDefault();
                if (workerLogIn != null)
                {
                    MenuWindow menu = new MenuWindow();
                    menu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!",
                            "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbLogin.Clear();
                    pbPassword.Clear();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Поля Логин и Пароль обязательны к заполнению!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            tbLogin.Clear();
            pbPassword.Clear();

        }
    }
}
