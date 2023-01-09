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
    /// Interaction logic for OrderForList.xaml
    /// </summary>
    public partial class OrderForList : Window
    {
        public OrderForList()
        {
            InitializeComponent();
            try
            {
                App.OrderCollection.Clear();
                foreach (var item in App.bl!.order.Get())
                {
                    App.OrderCollection.Add(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\nTake cover. coumputer might explode");
            }
        }


        /// <summary>
        /// switch to the update-order window. works by double clicking an order in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewOrderForList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new Order(((BO.OrderForList)ListViewOrderForList.SelectedItem).ID.ToString(), true).Show();
            Close();
        }
        
        /// <summary>
        /// Goes back to the Manager Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new ManagerWindow().Show();
            Close();
        }
    }
}
