using EbaniyMagaz.Model;
using EbaniyMagaz.Views.Pages;
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

namespace EbaniyMagaz.Views.Windows
{
    public partial class Store : Window
    {
        private LocalData _localData;
        public Store()
        {
            InitializeComponent();
            LocalData localData = new LocalData();
            _localData = localData;
            _localData.CartObject = new Cart(new List<CartLine>());
        }

        private void NavMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _localData.MainFrame = MainFrame;
            switch (NavMenu.SelectedIndex)
            {
                case 1:
                    _localData.ProductType = ProductType.processors;
                    TemplatePage processorsPage = new TemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(processorsPage);
                    break;
                case 2:
                    _localData.ProductType = Model.ProductType.videocards;
                    TemplatePage videoPage = new TemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(videoPage);
                    break;
                case 3:
                    _localData.ProductType = Model.ProductType.motherboard;
                    TemplatePage mboards = new TemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(mboards);
                    break;
                case 4:
                    _localData.ProductType = Model.ProductType.ram;
                    TemplatePage rams = new TemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(rams);
                    break;
                case 5:
                    _localData.ProductType = Model.ProductType.harddrives;
                    TemplatePage hdd = new TemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(hdd);
                    break;
                case 6:
                    _localData.ProductType = Model.ProductType.powersuplies;
                    TemplatePage pwr = new TemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(pwr);
                    break;
                case 7:
                    _localData.ProductType = Model.ProductType.cooling;
                    TemplatePage cooling = new TemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(cooling);
                    break;
                case 8:
                    _localData.ProductType = Model.ProductType.cases;
                    TemplatePage cases = new TemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(cases);
                    break;
            }
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            CartPage cartPage = new CartPage(_localData);
            MainFrame.NavigationService.Navigate(cartPage);
        }
    }
}
