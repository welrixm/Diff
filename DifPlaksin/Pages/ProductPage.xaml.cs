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
using DifPlaksin.Components;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace DifPlaksin.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            DBConnect.db.Product.Load();
            Products = DBConnect.db.Product.Local;
        }
        public ObservableCollection<Product> Products
        {
            get { return (ObservableCollection<Product>)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }
        public static readonly DependencyProperty ProductsProperty = DependencyProperty.Register("Products", typeof(ObservableCollection<Product>), typeof(ProductPage));
       private void Refresh()
        {
            IEnumerable<Product> prodL = DBConnect.db.Product;
            ObservableCollection<Product> products = Products;
            if (TxtSearch == null)
                return;
            if(TxtSearch.Text.Length > 0)
            {
                prodL = prodL.Where(x => x.Name.StartsWith(TxtSearch.Text) || x.Description.StartsWith(TxtSearch.Text));
            }
            ProductList.ItemsSource = prodL.ToList();
        }
       
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selProduct = (sender as Button).DataContext as Product;
            Navigation.NextPage(new Nav("Edit Product", new EditPage(selProduct)));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selProduct = (sender as Button).DataContext as Product;
            if(MessageBox.Show("Вы хотите удалить эту запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                selProduct.IsActive = false;
                DBConnect.db.Product.Remove(selProduct);
                MessageBox.Show("Delete");
                DBConnect.db.SaveChanges();
                ProductList.ItemsSource = selProduct.ToString();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Nav("Add Product", new EditPage(new Product())));
        }

        private void TxtSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
