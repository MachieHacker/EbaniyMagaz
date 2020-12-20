using EbaniyMagaz.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для HomePageStore.xaml
    /// </summary>
    public partial class HomePageStore : Page
    {
        private LocalData localdata;

        public HomePageStore(LocalData localdata)
        {
            InitializeComponent();
            this.localdata = localdata;
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            StoreProccesors.ItemsSource = DatabaseManager.Upload("SELECT * FROM  components");   

        }

        private void asd(object sender, SelectionChangedEventArgs e)
        {
            if (StoreProccesors.ItemsSource != null)
            {
                localdata.Component = StoreProccesors.SelectedItem as Component;
                localdata.MainFrame.NavigationService.Navigate(new Pages.Opened(localdata));
            }

            
            
        }

        
    }
}
