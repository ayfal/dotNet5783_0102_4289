//using BlApi;
//using BlImplementation;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
       public ManagerWindow()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// open the product list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Product_Click(object sender, RoutedEventArgs e)
        { 
            new ProductForList().Show();
            Close();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            new OrderForList().Show();            
            Close();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
