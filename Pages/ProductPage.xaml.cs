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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            LVProducts.ItemsSource = context.Product.OrderBy(i => i.idProduct).ToList();

            if (workerLogIn.idAccess == 2)
            {
                btnAddProduct.Visibility = Visibility.Collapsed;
                btnEditProduct.Visibility = Visibility.Collapsed;
            }

            cmbSort.ItemsSource = new List<String>
            {
                "По умолчанию",
                "Название (от А до Я)",
                "Название (от Я до А)",
                "Гарантия (по возрастанию)",
                "Гарантия (по убыванию)",
                "Цена (по возрастанию)",
                "Цена (по убыванию)",
                "Наличие (по возрастанию)",
                "Наличие (по убыванию)",
            };
        }

        public void Filter()
        {
            var list = context.Product.Where(i => i.NameProduct.Contains(tbSearch.Text) || i.Description.Contains(tbSearch.Text)).ToList();

            switch (cmbSort.SelectedIndex)
            {
                case 1:
                    list = list.OrderBy(i => i.NameProduct).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.NameProduct).ToList();
                    break;
                case 3:
                    list = list.OrderBy(i => i.GuaranteeInYears).ToList();
                    break;
                case 4:
                    list = list.OrderByDescending(i => i.GuaranteeInYears).ToList();
                    break;
                case 5:
                    list = list.OrderBy(i => i.Price).ToList();
                    break;
                case 6:
                    list = list.OrderByDescending(i => i.Price).ToList();
                    break;
                case 7:
                    list = list.OrderBy(i => i.CountInStock).ToList();
                    break;
                case 8:
                    list = list.OrderByDescending(i => i.CountInStock).ToList();
                    break;
                default:
                    break;
            }

            LVProducts.ItemsSource = list;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Clear();
            cmbSort.SelectedIndex = 0;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditProductWindow addEditProduct = new AddEditProductWindow();
            addEditProduct.ShowDialog();
            Filter();
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (LVProducts.SelectedItem is Product product)
            {
                prod = product;
                checkEdit = true;
                AddEditProductWindow addEditProduct = new AddEditProductWindow();
                addEditProduct.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите запись из списка!", "Редактирование продукта", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            Filter();
        }
    }
}
