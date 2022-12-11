using BlApi;
using BlImplementation;
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
    /// Interaction logic for ProductForList.xaml
    /// </summary>
    public partial class ProductForList : Window
    {
        IBl bl = new Bl();
        public ProductForList()
        {
            InitializeComponent();
            ListViewProductForList.ItemsSource = bl._product.GetProductsList();
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));

        }

        private void ListViewProductForList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewProductForList.ItemsSource = bl._product.GetProductsList(c => c?.Category == (DO.Enums.Category)CategorySelector.SelectedItem);
        }

        private void Button_Click(object sender, RoutedEventArgs e) => new Product().Show();
    }
}
