using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static BlApi.IBl? bl = BlApi.Factory.Get();
        public static ObservableCollection<BO.ProductForList?> ProductForListCollection = new ObservableCollection<BO.ProductForList?>();
        public static ObservableCollection<BO.ProductItem?> ProductItemCollection = new ObservableCollection<BO.ProductItem?>();
        public static ObservableCollection<BO.OrderForList?> OrderCollection = new ObservableCollection<BO.OrderForList?>();
        public static BO.Cart cart;
        public static ListCollectionView view = new ListCollectionView(ProductItemCollection);
        public static Array categories = Enum.GetValues(typeof(BO.Enums.Category));
        public static BO.Order order = new BO.Order();
    }
    public class WindowToBoolConverter : IValueConverter
    {
        //convert from source property type to target property type
        public
        object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Window owner = (Window)value;
            if (owner == null)//change this
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //convert from target property type to source property type
        public
        object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw
            new NotImplementedException();
        }
    }
}
