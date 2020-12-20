using EbaniyMagaz.Views.AdminPages;
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
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private LocalData _localData;
        public AdminPanel()
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
                    TabelUsers users = new TabelUsers(_localData);
                    MainFrame.NavigationService.Navigate(users);
                    break;
                case 1:
                    _localData.ProductType = Model.ProductType.processors;
                    AdminTemplatePage processorsPage = new AdminTemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(processorsPage);
                    break;
                case 2:
                    _localData.ProductType = Model.ProductType.videocards;
                    AdminTemplatePage videoPage = new AdminTemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(videoPage);
                    break;
                case 3:
                    _localData.ProductType = Model.ProductType.motherboard;
                    AdminTemplatePage mboards = new AdminTemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(mboards);
                    break;
                case 4:
                    _localData.ProductType = Model.ProductType.ram;
                    AdminTemplatePage rams = new AdminTemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(rams);
                    break;
                case 5:
                    _localData.ProductType = Model.ProductType.harddrives;
                    AdminTemplatePage hdd = new AdminTemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(hdd);
                    break;
                case 6:
                    _localData.ProductType = Model.ProductType.powersuplies;
                    AdminTemplatePage pwr = new AdminTemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(pwr);
                    break;
                case 7:
                    _localData.ProductType = Model.ProductType.cooling;
                    AdminTemplatePage cooling = new AdminTemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(cooling);
                    break;
                case 8:
                    _localData.ProductType = Model.ProductType.cases;
                    AdminTemplatePage cases = new AdminTemplatePage(_localData);
                    MainFrame.NavigationService.Navigate(cases);
                    break;

            }
        }
    }
}
