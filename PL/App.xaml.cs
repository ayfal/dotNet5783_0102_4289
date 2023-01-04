using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

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
        public static BO.Cart cart = new BO.Cart();
        //{
        //    get
        //    {
        //        return bl!.product.GetProductsList();
        //    }
        //}        
    }
}
