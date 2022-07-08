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
    /// Логика взаимодействия для ChangeStatusWindow.xaml
    /// </summary>
    public partial class ChangeStatusWindow : Window
    {
        public ChangeStatusWindow()
        {
            InitializeComponent();
            var application = context.Applications.Where(i => i.idApplication == idApp).FirstOrDefault();
            List<Status> status = context.Status.ToList();
            cmbChangeStatus.ItemsSource = status;
            cmbChangeStatus.DisplayMemberPath = "Title";
            cmbChangeStatus.SelectedItem = application.Status;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var application = context.Applications.Where(i => i.idApplication == idApp).FirstOrDefault();
            application.idStatus = cmbChangeStatus.SelectedIndex + 1;
            context.SaveChanges();
            this.Close();
        }
    }
}
