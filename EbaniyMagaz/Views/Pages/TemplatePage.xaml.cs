using EbaniyMagaz.Data;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace EbaniyMagaz.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Processors.xaml
    /// </summary>
    public partial class TemplatePage : Page
    {
        private LocalData localdata;

        public TemplatePage(LocalData localdata)
        {
            InitializeComponent();
            this.localdata = localdata;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            StoreProccesors.ItemsSource = DatabaseManager.Upload("SELECT * FROM  "+ localdata.ProductType.ToString());
        }

        private void asd(object sender, SelectionChangedEventArgs e)
        {
            if (StoreProccesors.SelectedItem != null)
            {
                localdata.Component = StoreProccesors.SelectedItem as Component;

                localdata.MainFrame.NavigationService.Navigate(new Pages.Opened(localdata));
            }
        }

    }
        
}

