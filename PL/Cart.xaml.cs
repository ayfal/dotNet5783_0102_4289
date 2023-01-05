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

            //App.view.IsLiveSorting = true;
            //App.view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            //ListViewProductForList.
            //DataContext = App.ProductItemCollection;
            InitializeComponent();
            //try
            //{
            //    foreach (var item in App.bl!.product.GetProductsList())
            //        App.ProductItemCollection.Add(App.bl.product.GetProductDetails(item.ID, App.cart));
            //    //ListViewProductForList.ItemsSource = App.bl.product.GetProductsList();
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message + "\nTake cover. coumputer might explode");
            //}
            ////CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));

        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            var product = ((BO.ProductItem)(((Button)sender).DataContext));
            App.bl.cart.AddProduct(App.cart, product.ID);
            App.ProductItemCollection.Remove(product);
            App.ProductItemCollection.Add(App.bl.product.GetProductDetails(product.ID, App.cart));
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            var product = ((BO.ProductItem)(((Button)sender).DataContext));
            if (product.Amount > 0)
            {
                App.bl.cart.UpdateAmount(App.cart, product.ID, (product.Amount) - 1);
                App.ProductItemCollection.Remove(product);
                App.ProductItemCollection.Add(App.bl.product.GetProductDetails(product.ID, App.cart));
            }
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
                App.ProductItemCollection.Clear();
                foreach (var item in App.bl?.product.GetProductsList(CategorySelector.SelectedItem != null ? c => c?.Category == (DO.Enums.Category)CategorySelector.SelectedItem : null)!)
                {
                    App.ProductItemCollection.Add(App.bl.product.GetProductDetails(item.ID, App.cart));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nWho would have thought?");
            }
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

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            new Cart().Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
