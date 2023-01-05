using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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
        public static BO.Cart cart = new BO.Cart() { Items = new List<BO.OrderItem>()! };
        public static ListCollectionView view = new ListCollectionView(ProductItemCollection);

    }
}
