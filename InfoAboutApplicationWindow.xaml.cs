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
    /// Логика взаимодействия для InfoAboutApplicationWindow.xaml
    /// </summary>
    public partial class InfoAboutApplicationWindow : Window
    {
        public InfoAboutApplicationWindow()
        {
            InitializeComponent();
            var application = context.Applications.Where(i => i.idApplication == idApp).FirstOrDefault();
            tbFIO.Text = application.Client.FIO;
            tbAddress.Text = application.Client.Address;
            tbPhone.Text = application.Client.Phone;
            tbEmail.Text = application.Client.Email;
            tbDateOfCreation.Text = application.DateOfCreation.ToString("dd.MM.yyyy");
            tbDateOfCompletion.Text = application.DateOfCompletion.ToString("dd.MM.yyyy");
            tbStatus.Text = application.Status.Title;
            tbStatus.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString(application.Status.Color));
            tbTotalSum.Text = application.TotalPrice.ToString();
            LVCheque.ItemsSource = context.Cheque.Where(i => i.idApplication == idApp).ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var application = context.Applications.Where(i => i.idApplication == idApp).FirstOrDefault();
            if (application.idStatus == 1)
            {
                MessageBox.Show("Статус заявки: завершено. Удаление запрещено!",
                           "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show("Вы действительно хотите удалить запись?",
                   "Удаление заявки", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                    context.Applications.Remove(context.Applications.Where(i => i.idApplication == application.idApplication).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Удаление заявки", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.Close();

        }

        private void btnChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            var application = context.Applications.Where(i => i.idApplication == idApp).FirstOrDefault();

            if (application.idStatus == 1)
            {
                MessageBox.Show("Статус заявки: завершено. Изменение статуса запрещено!",
                           "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ChangeStatusWindow changeStatus = new ChangeStatusWindow();
            changeStatus.ShowDialog();
            tbStatus.Text = application.Status.Title;
            tbStatus.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString(application.Status.Color));
        }
    }
}
