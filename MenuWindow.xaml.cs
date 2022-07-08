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
using GazLink.Pages;

namespace GazLink
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            frame = frameMain;
            frame.Navigate(new DefaultPage());
            if (workerLogIn.idAccess == 2)
            {
                btnWorkersList.Visibility = Visibility.Collapsed;
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnApplicationsList_Click(object sender, RoutedEventArgs e)
        {
            frame = frameMain;
            frame.Navigate(new ApplicationsPage());
        }

        private void AddApplication_Click(object sender, RoutedEventArgs e)
        {
            frame = frameMain;
            frame.Navigate(new AddApplicationPage());
        }

        private void btnClientLsit_Click(object sender, RoutedEventArgs e)
        {
            frame = frameMain;
            frame.Navigate(new ClientsPage());
        }

        private void btnWorkersList_Click(object sender, RoutedEventArgs e)
        {
            frame = frameMain;
            frame.Navigate(new WorkersPage());
        }

        private void btnProductList_Click(object sender, RoutedEventArgs e)
        {
            frame = frameMain;
            frame.Navigate(new ProductPage());
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            frame = frameMain;
            frame.Navigate(new AccountPage());
        }
    }
}
