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
    /// Interaction logic for CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        public CatalogWindow()
        {
           //ListViewProductForList.
            DataContext = App.ProductItemCollection;
            InitializeComponent();
            try
            {
                foreach (var item in App.bl!.product.GetProductsList())
                {
                    App.ProductItemCollection.Add(App.bl.product.GetProductDetails(item.ID, App.cart));
                }
                //ListViewProductForList.ItemsSource = App.bl.product.GetProductsList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\nTake cover. coumputer might explode");
            }
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));

        }

        private void ListViewProductItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
