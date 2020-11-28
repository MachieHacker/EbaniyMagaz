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
        }

        private void NavMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _localData.MainFrame = MainFrame;
            switch (NavMenu.SelectedIndex)
            {
                case 0:
                    HomePageStore homePage = new HomePageStore(_localData);
                    MainFrame.NavigationService.Navigate(homePage);
                    break;
                case 1:
                    ProcessorsPage processorsPage = new ProcessorsPage(_localData);
                    MainFrame.NavigationService.Navigate(processorsPage);
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
