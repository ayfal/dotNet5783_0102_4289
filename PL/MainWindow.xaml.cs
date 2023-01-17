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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }       
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            new ManagerWindow().Show();
            Close();
        }
        private void btnTrack_Click(object sender, RoutedEventArgs e)
        {
            try { new OrderTracking(txtbxOrderNo.Text).Show(); }
            catch { MessageBox.Show("Order tracked down and killed, sir. Awaiting further instructions"); }
        }
        private void btnNewOrder_Click(object sender, RoutedEventArgs e)
        {
            App.cart = new BO.Cart() { Items = new List<BO.OrderItem>()! };
            new CatalogWindow().Show();
            Close();
        }
    }
}
