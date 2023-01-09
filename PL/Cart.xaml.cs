using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for CatalogWindow.xaml
    /// </summary>
    public partial class Cart : Window
    {
        public Cart()
        {
            InitializeComponent();
        }
        private void bteCheckOut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = App.bl!.cart.Checkout(App.cart, App.cart.CustomerName!, App.cart.CustomerEmail!, App.cart.CustomerAddress!);
                MessageBox.Show($"Your Order ID is {order.ID} \nSo long, Sucker!");
                new MainWindow().Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Goes back to the Catalog Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new CatalogWindow().Show();
            Close();
        }
    }
}
