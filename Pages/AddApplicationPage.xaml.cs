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
    /// Логика взаимодействия для AddApplicationPage.xaml
    /// </summary>
    public partial class AddApplicationPage : Page
    {
        public List<Product> cheque = new List<Product>();
        public int count = 1;
        public AddApplicationPage()
        {
            InitializeComponent();
            LVAppClient.ItemsSource = context.Client.ToList().OrderBy(i => i.idClient);
            LVAppProducts.ItemsSource = context.Product.ToList().OrderBy(i => i.idProduct);
        }

        private void tbSearchClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list = context.Client.Where(i => i.FirstName.Contains(tbSearchClient.Text) || i.LastName.Contains(tbSearchClient.Text) || i.MiddleName.Contains(tbSearchClient.Text)
            || i.Address.Contains(tbSearchClient.Text) || i.Phone.Contains(tbSearchClient.Text)).ToList();

            LVAppClient.ItemsSource = list;
        }

        public void Filter()
        {
            var list = context.Product.ToList().Where(i=> cheque.Contains(i)!=true).Where(i => i.NameProduct.Contains(tbSearchProduct.Text)).ToList();
            LVAppProducts.ItemsSource = list;

            var list1 = context.Product.ToList().Where(i => cheque.Contains(i)).ToList();
            LVCheque.ItemsSource = list1;

            int totalSum = 0;
            foreach (Product product in LVCheque.Items)
            {
                totalSum += product.PriceCount;
            }
            tbTotalSum.Text = Convert.ToString(totalSum);
        }


        private void tbSearchProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbSearchClient.Clear();
            tbSearchProduct.Clear();
            dpDate.SelectedDate = null;
            LVAppClient.SelectedItem = null;
            LVAppProducts.SelectedItem = null;
            cheque.Clear();
            Filter();
        }

        private void btnAddInCheque_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var product = btn.DataContext as Product;
            cheque.Add(product);
            Filter();
        }

        private void btnRemoveFromCheque_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var product = btn.DataContext as Product;
            cheque.Remove(product);
            product.count = 1;
            Filter();
        }

        private void btnAddApplication_Click(object sender, RoutedEventArgs e)
        {
            if (dpDate.SelectedDate == null)
            {
                MessageBox.Show("Выберете дату установки",
                    "Добавление заявки", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dpDate.SelectedDate < DateTime.Now)
            {
                MessageBox.Show("Дата установки не может быть позже текущей даты",
                    "Добавление заявки", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (cheque.Count == 0)
            {
                MessageBox.Show("Выберите оборудование!",
                "Добавление заявки", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (LVAppClient.SelectedItem is Client client)
            {
                var app = new Applications
                {
                    idClient = client.idClient,
                    DateOfCreation = DateTime.Now,
                    DateOfCompletion = dpDate.SelectedDate.Value,
                    idStatus = 2
                };

                foreach(Product pr in cheque)
                {
                    app.Cheque.Add(new Cheque
                    {
                        Product = pr,
                        Quantity = pr.count
                    });
                }
                context.Applications.Add(app);
                context.SaveChanges();
                MessageBox.Show("Заявка успешно добавлена!",
                "Добавление заявки", MessageBoxButton.OK, MessageBoxImage.Information);
                tbSearchClient.Clear();
                tbSearchProduct.Clear();
                dpDate.SelectedDate = null;
                LVAppClient.SelectedItem = null;
                LVAppProducts.SelectedItem = null;
                cheque.Clear();
                Filter();
            }
            else
            {
                MessageBox.Show("Выберите клиента!",
                "Добавление заявки", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var product = btn.DataContext as Product;
            if (product.count > 1)
            {
                product.count--;
            }
            Filter();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var product = btn.DataContext as Product;
            product.count++;
            Filter();
        }
    }
}
