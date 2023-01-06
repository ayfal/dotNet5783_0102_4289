﻿//using BlApi;
//using BlImplementation;
using System;
using System.Collections.Generic;
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
        //int integer;
        //double dbl;

        //BlApi.IBl? bl = BlApi.Factory.Get();
        /// <summary>
        /// constructor.constructs the windows either in add mode or in update mode
        /// </summary>
        /// <param name = "id" ></ param >
        public Order(string? id)
        {
            InitializeComponent();
            //if (this.Owner == null) //manager mode
            //{
            //    txtID.IsReadOnly = false;
            //    txtName.IsReadOnly = false;
            //    txtEmail.IsReadOnly = false;
            //    txtAddress.IsReadOnly = false;
            //    txtOrderDate.IsReadOnly = false;
            //    txtShipDate.IsReadOnly = false;
            //    txtDeliveryDate.IsReadOnly = false;
            //    btnAdd.Visibility = Visibility.Visible;
            //    btnUpdate.Visibility = Visibility.Hidden;
            //}
            //else //customer mode
            //{
            //    txtID.IsReadOnly = true;
            //    txtName.IsReadOnly = true;
            //    txtEmail.IsReadOnly = true;
            //    txtAddress.IsReadOnly = true;
            //    txtOrderDate.IsReadOnly = true;
            //    txtShipDate.IsReadOnly = true;
            //    txtDeliveryDate.IsReadOnly = true;
            //    txtID.Text = id;
            //    BO.Product product = bl.product.GetProdcutDetails(int.Parse(id));
            //    txtName.Text = product.Name;
            //    txtPrice.Text = product.Price.ToString();
            //    cmbbxCategory.Text = product.Category.ToString();
            //    txtInStock.Text = product.InStock.ToString();
            //    btnAdd.Visibility = Visibility.Hidden;
            //    btnUpdate.Visibility = Visibility.Visible;
            //}
        }

        ///// <summary>
        ///// generates a product object from the textboxes
        ///// </summary>
        ///// <returns>BO.Product</returns>
        ///// <exception cref="Exception"></exception>
        //private BO.Product GenerateProduct()
        //{
        //    BO.Product product = new BO.Product()
        //    {
        //        ID = int.TryParse(txtID.Text, out integer) ? integer : throw new Exception("Not a valid ID"),//todo decide how to initialize
        //        Name = txtName.Text,
        //        Category = Enum.TryParse<BO.Enums.Category>(cmbbxCategory.Text, out BO.Enums.Category c) ? c : throw new Exception("Not a valid category. Meshugener!"),
        //        Price = double.TryParse(txtPrice.Text, out dbl) ? dbl : throw new Exception("Not a valid Price"),
        //        InStock = int.TryParse(txtInStock.Text, out integer) ? integer : throw new Exception("Not a valid amount")
        //    };
        //    return product;
        //}

        ///// <summary>
        ///// adds the product to the DB
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        bl?.product.Add(GenerateProduct());
        //        this.Close();
        //        new ProductForList().Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + "\nWARNING: errors like this may cause volcanic eruptions");
        //    }
        //}

        ///// <summary>
        ///// updates the product in the DB
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Update_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        bl?.product.Update(GenerateProduct());
        //        this.Close();
        //        new ProductForList().Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + "\nWARNING: errors like this may cause World War III");
        //    }
        //}

        public
class WindowToBoolConverter : IValueConverter
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
}
