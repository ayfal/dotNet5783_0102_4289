using BlApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ProductForList.xaml
    /// </summary>
    public partial class ProductForList : Window
    {
        /// <summary>
        /// constructor. populates a list with all the products, and a filter selector with all the categories 
        /// </summary>
        public ProductForList()
        {
            InitializeComponent();
            try
            {
                foreach (var item in App.bl!.product.GetProductsList())
                {
                    App.ProductForListCollection.Add(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\nTake cover. coumputer might explode");
            }
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));

        }

        /// <summary>
        /// filter the list by category, or remove filtering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //filter the list. if no filter is selected, don't filter:
                ListViewProductForList.ItemsSource = App.bl?.product.GetProductsList(CategorySelector.SelectedItem != null ? c => c?.Category == (DO.Enums.Category)CategorySelector.SelectedItem : null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\nWho would have thought?");
            }
        }

        /// <summary>
        /// switch to the add-product window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            new Product().Show();
        }

        /// <summary>
        /// switch to the update-product window. works by double clicking a product in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewProductForList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            new Product(((BO.ProductForList)ListViewProductForList.SelectedItem).ID.ToString()).Show();
        }

        /// <summary>
        /// clear the filter combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CategorySelector.SelectedItem = null;
        }
    }
}
