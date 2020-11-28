using MySql.Data.MySqlClient;
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
    /// Логика взаимодействия для Processors.xaml
    /// </summary>
    public partial class Processors : Page
    {
        private LocalData localdata;

        
        public Processors(LocalData localdata)
        {
            InitializeComponent();
            this.localdata = localdata;
        }

        private List<Component> Upload(string cmd)
        {
            using (MySqlConnection connection = new MySqlConnection(DataBase.connection))
            {
                List<Component> components = new List<Component>();
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(cmd, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            components.Add(new Component()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Manufacturer = reader["Manufacturer"].ToString(),
                                Model = reader["Model"].ToString(),
                                Specification = reader["Specification"].ToString(),
                                Price = reader["Price"].ToString()

                            });
                        }
                    }
                    command.ExecuteNonQuery();
                }

                return components;

            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            StoreProccesors.ItemsSource = Upload("SELECT * FROM  processors");
        }

        private void asd(object sender, SelectionChangedEventArgs e)
        {
            if (StoreProccesors.SelectedItem != null)
            {
                localdata.Component = StoreProccesors.SelectedItem as Component;

                localdata.MainFrame.NavigationService.Navigate(new Pages.Opened(localdata));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (StoreProccesors.SelectedItem != null)
            {
                var element = StoreProccesors.SelectedItem as Component;

                var list = new List<Component>();
                list.Add(element);

                //localdata.CartPage

                
            }
        }
    }
        
}

