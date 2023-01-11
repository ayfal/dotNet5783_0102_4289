//using BlApi;
//using BlImplementation;
using BO;
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
        public static BO.Product product;
        public static bool isAddMode;

        /// <summary>
        /// constructor. constructs the windows either in add mode or in update mode 
        /// </summary>
        /// <param name="id"></param>
        public Product(string? id = null)
        {
            isAddMode = id == null;
            if (isAddMode) product = new BO.Product();
            else product = App.bl.product.GetProdcutDetails(int.Parse(id));//update mode
            InitializeComponent();
        }

        ///// <summary>
        ///// generates a product object from the textboxes
        ///// </summary>
        ///// <returns>BO.Product</returns>
        ///// <exception cref="Exception"></exception>
        //private BO.Product GenerateProduct()
        //{
        //    BO.Product product = new BO.Product()
        //    {
        //        ID = int.TryParse(txtID.Text, out integer) ? integer : throw new Exception("Not a valid ID"),//todo decide how to initialize
        //        Name = txtName.Text,
        //        Category = Enum.TryParse<BO.Enums.Category>(cmbbxCategory.Text, out BO.Enums.Category c) ? c : throw new Exception("Not a valid category. Meshugener!"),
        //        Price = double.TryParse(txtPrice.Text, out dbl) ? dbl : throw new Exception("Not a valid Price"),
        //        InStock = int.TryParse(txtInStock.Text, out integer) ? integer : throw new Exception("Not a valid amount")
        //    };
        //    return product;
        //}

        /// <summary>
        /// adds the product to the DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BO.ProductForList p = new BO.ProductForList();
                //p.CopyProperties(App.bl?.product.Add(GenerateProduct()));
                p.CopyProperties(App.bl?.product.Add(product));
                App.ProductForListCollection.Add(p);
                new ProductForList().Show();
                Close();
                //new ProductForList().Show();
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
                BO.ProductForList p = new BO.ProductForList();
                //p.CopyProperties(App.bl?.product.Update(GenerateProduct()));
                p.CopyProperties(App.bl?.product.Update(product));
                App.ProductForListCollection.Add(p);
                new ProductForList().Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nWARNING: errors like this may cause World War III");
            }
        }

        /// <summary>
        /// Goes back to the Prodcut for list Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new ProductForList().Show();
            Close();
        }
    }
}
