using BlApi;
using BlImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        int integer;
        double dbl;

        IBl bl = new Bl();
        public Product(string id = null)
        {
            InitializeComponent();
            if (id == null)//update mode
            {
                txtID.IsReadOnly = true;
                btnAdd.Visibility = Visibility.Hidden;
                btnUpdate.Visibility = Visibility.Visible;
            }
            else // add mode
            {
                txtID.IsReadOnly = false;
                txtID.Text = id;
                BO.Product product = bl._product.GetProdcutDetails(int.Parse(id));
                txtName.Text = product.Name;
                txtPrice.Text = product.Price.ToString();
                txtCategory.Text = product.Category.ToString();
                txtInStock.Text = product.InStock.ToString();
                btnAdd.Visibility = Visibility.Visible;
                btnUpdate.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// generates a product object from the textboxes
        /// </summary>
        /// <returns>BO.Product</returns>
        /// <exception cref="Exception"></exception>
        private BO.Product GenerateProduct()
        {
            BO.Product product = new BO.Product()
            {
                ID = int.TryParse(txtID.Text, out integer) ? integer : throw new Exception("dfgdfgdfg"),//todo decide how to initialize
            };
            if (int.TryParse(txtID.Text, out integer)) product.ID = integer;
            else throw new Exception("Not a valid ID");//todo what exception to throw, if any?
            product.Name = txtName.Text;
            if (int.TryParse(txtCategory.Text, out integer) && Enum.IsDefined(typeof(BO.Enums.Category), integer)) product.Category = (BO.Enums.Category)integer;
            else throw new Exception("Not a valid category");
            if (double.TryParse(txtPrice.Text, out dbl)) product.Price = dbl;
            else throw new Exception("Not a valid Price");
            if (int.TryParse(txtInStock.Text, out integer)) product.InStock = integer;
            else throw new Exception("Not a valid amount");
            return product;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bl._product.Add(GenerateProduct());
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            bl._product.Update(GenerateProduct());
        }
    }
}
