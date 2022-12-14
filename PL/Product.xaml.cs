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
        /// <summary>
        /// constructor. constructs the windows either in add mode or in update mode 
        /// </summary>
        /// <param name="id"></param>
        public Product(string? id = null)
        {
            InitializeComponent();
            cmbbxCategory.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            if (id == null) //add mode
            {
                txtID.IsReadOnly = false;
                btnAdd.Visibility = Visibility.Visible;
                btnUpdate.Visibility = Visibility.Hidden;
            }
            else //update mode
            {
                txtID.IsReadOnly = true;
                txtID.Text = id;
                BO.Product product = bl._product.GetProdcutDetails(int.Parse(id));
                txtName.Text = product.Name;
                txtPrice.Text = product.Price.ToString();
                cmbbxCategory.Text = product.Category.ToString();
                txtInStock.Text = product.InStock.ToString();
                btnAdd.Visibility = Visibility.Hidden;
                btnUpdate.Visibility = Visibility.Visible;
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
                ID = int.TryParse(txtID.Text, out integer) ? integer : throw new Exception("Not a valid ID"),//todo decide how to initialize
                Name = txtName.Text,
                Category = Enum.TryParse<BO.Enums.Category>(cmbbxCategory.Text, out BO.Enums.Category c) ? c : throw new Exception("Not a valid category. Meshugener!"),
                Price = double.TryParse(txtPrice.Text, out dbl) ? dbl : throw new Exception("Not a valid Price"),
                InStock = int.TryParse(txtInStock.Text, out integer) ? integer : throw new Exception("Not a valid amount")
            };
            return product;
        }

        /// <summary>
        /// adds the product to the DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl._product.Add(GenerateProduct());
                this.Close();
                new ProductForList().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nWARNING: errors like this may cause volcanic eruptions");
            }
        }

        /// <summary>
        /// updates the product in the DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl._product.Update(GenerateProduct());
                this.Close();
                new ProductForList().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nWARNING: errors like this may cause World War III");
            }
        }
    }
}
