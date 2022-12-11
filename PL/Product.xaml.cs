using BlApi;
using BlImplementation;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        IBl bl = new Bl();
        public Product()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            BO.Product product = new Product() // it's not work good!
            {
                ID = ID,
                Name =Name,
                Price = Price ,
                Category = Category,
                InStock = productD?.InStock ?? throw new NullReferenceException()
            };
            bl._product.Add()
        }
    }
}
