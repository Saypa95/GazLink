using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditProductWindow.xaml
    /// </summary>
    public partial class AddEditProductWindow : Window
    {
        private string pathPhoto;
        public AddEditProductWindow()
        {
            InitializeComponent();
            if (checkEdit)
            {
                tbNameProduct.Text = prod.NameProduct;
                tbDescription.Text = prod.Description;
                tbGuarantee.Text = prod.GuaranteeInYears.ToString();
                tbPrice.Text = prod.Price.ToString();
                tbCountInStock.Text = prod.CountInStock.ToString();
                photoProduct.Source = prod.ImgSource;
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

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Product";
            if (fileDialog.ShowDialog() == true)
            {
                photoProduct.Source = new BitmapImage(new Uri(fileDialog.FileName));
                pathPhoto = "Product\\" + new FileInfo(fileDialog.FileName).Name;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkEdit)
            {
                if (pathPhoto != null)
                {
                    prod.NameProduct = tbNameProduct.Text;
                    prod.Description = tbDescription.Text;
                    prod.GuaranteeInYears = Convert.ToDouble(tbGuarantee.Text);
                    prod.Price = Convert.ToDecimal(tbPrice.Text);
                    prod.CountInStock = Convert.ToInt32(tbCountInStock.Text);
                    prod.Photo = pathPhoto;

                }
                else
                {
                    prod.NameProduct = tbNameProduct.Text;
                    prod.Description = tbDescription.Text;
                    prod.GuaranteeInYears = Convert.ToDouble(tbGuarantee.Text);
                    prod.Price = Convert.ToDecimal(tbPrice.Text);
                    prod.CountInStock = Convert.ToInt32(tbCountInStock.Text);
                }
                context.SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                checkEdit = false;
            }
            else
            {
                if (pathPhoto != null)
                {
                    context.Product.Add(new Product
                    {
                        NameProduct = tbNameProduct.Text,
                        Description = tbDescription.Text,
                        GuaranteeInYears = Convert.ToDouble(tbGuarantee.Text),
                        Price = Convert.ToDecimal(tbPrice.Text),
                        CountInStock = Convert.ToInt32(tbCountInStock.Text),
                        Photo = pathPhoto
                    });
                    context.SaveChanges();
                    MessageBox.Show("Товар успешно добавлен!",
                    "Добавление товара", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    checkEdit = false;
                }
                else
                {
                    MessageBox.Show($"Выберите фото товара!",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (context.Cheque.Where(i => i.idProduct == prod.idProduct).FirstOrDefault() != null)
            {
                MessageBox.Show("Имеются заявки с данным оборудование, удаление запрещено!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var result = MessageBox.Show("Вы действительно хотите удалить товар?",
                       "Удаление товара", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    context.Product.Remove(context.Product.Where(i => i.idProduct == prod.idProduct).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Удаление товара", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                this.Close();
            }
        }
    }
}
