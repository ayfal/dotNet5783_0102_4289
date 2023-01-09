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
    /// Interaction logic for OrderTracking.xaml
    /// </summary>
    public partial class OrderTracking : Window
    {
        string orderID;
        public static BO.OrderTracking OrderLog;
        public OrderTracking(string order)
        {
            OrderLog = int.TryParse(order, out int ID) ? App.bl!.order.Track(ID) : throw new Exception("that's the weirdest integer i've ever seen");
            InitializeComponent();
            orderID = order;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            new Order(orderID, false).Show();
            Close();
        }

        /// <summary>
        /// Goes back to the Main Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
