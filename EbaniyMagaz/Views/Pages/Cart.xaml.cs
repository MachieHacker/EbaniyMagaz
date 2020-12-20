using EbaniyMagaz.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EbaniyMagaz.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        private LocalData localData;
        private Cart cartObj;

        public CartPage(LocalData localData)
        {
            InitializeComponent();

            this.localData = localData;
            this.cartObj = localData.CartObject;

            this.Loaded += CartPage_Loaded;
        }

        private void CartPage_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (CartLine item in localData.CartObject.Lines)
            {
                item.TotalPrice = localData.CartObject.ComputeTotalValue();
            }

            mmm.ItemsSource = localData.CartObject.Lines;
        }
        private void Delete_Position(object sender, RoutedEventArgs e)
        {
            if (mmm.SelectedValue != null)
            {
                localData.CartObject.Lines.Remove((CartLine)mmm.SelectedValue);
                mmm.ItemsSource = null;
                mmm.ItemsSource = localData.CartObject.Lines;
            }

        }


    }
}

