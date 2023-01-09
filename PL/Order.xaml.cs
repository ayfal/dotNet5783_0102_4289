//using BlApi;
//using BlImplementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using System.Xml.Linq;

namespace PL
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Order : Window
    {
        public static bool IsManager { get; set; }

        /// <summary>
        /// constructor.constructs the windows either in add mode or in update mode
        /// </summary>
        /// <param name = "id" ></ param >
        public Order(string id, bool isManager)
        {
            IsManager = isManager;
            App.order = App.bl!.order.GetOrderDetails(int.Parse(id));
            ShipDate = App.order.ShipDate;
            DeliveryDate = App.order.DeliveryDate;
            InitializeComponent();
        }
        private void Shipping_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.order = App.bl.order.UpdateShipping(App.order.ID);
                ShipDate = App.order.ShipDate;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Delivery_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.order = App.bl.order.UpdateDelivery(App.order.ID);
                DeliveryDate = App.order.DeliveryDate;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public DateTime? ShipDate
        {
            get { return (DateTime?)GetValue(ShipDateProperty); }
            set { SetValue(ShipDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShipDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShipDateProperty =
            DependencyProperty.Register("ShipDate", typeof(DateTime?), typeof(Order));



        public DateTime? DeliveryDate
        {
            get { return (DateTime?)GetValue(DeliveryDateProperty); }
            set { SetValue(DeliveryDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeliveryDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeliveryDateProperty =
            DependencyProperty.Register("DeliveryDate", typeof(DateTime?), typeof(Order));
        
        /// <summary>
        /// Goes back to the previous window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (IsManager) new OrderForList().Show();
            else new MainWindow().Show();
            Close();
        }
    }
}
