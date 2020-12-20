using EbaniyMagaz.Data;
using EbaniyMagaz.Model;
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

namespace EbaniyMagaz.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для TabelProcessors.xaml
    /// </summary>
    public partial class AdminTemplatePage : Page
    {
        private LocalData localdata;
        public AdminTemplatePage(LocalData localdata)
        {
            InitializeComponent();
            this.localdata = localdata;
            this.Loaded += TabelProcessors_Loaded;
        }

        private void TabelProcessors_Loaded(object sender, RoutedEventArgs e)
        {
            mmm.ItemsSource = DatabaseManager.Upload("SELECT * FROM  " + localdata.ProductType.ToString());
        }

        private void Delete_Position(object sender, RoutedEventArgs e)
        {
            Component item = mmm.SelectedItem as Component; 

            if (item != null)
            {
                using (MySqlConnection connection = new MySqlConnection(DataBase.connection))
                {
                    List<Component> components = new List<Component>();
                    connection.Open();

                    string cmd = "DELETE FROM `" + localdata.ProductType.ToString() + "`  WHERE `Id` = @ID";

                    using (MySqlCommand command = new MySqlCommand(cmd, connection))
                    {
                        command.Parameters.Add("@ID", MySqlDbType.VarChar).Value = item.Id;

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Удалено");

                        }
                        else
                        {
                            MessageBox.Show("Ошибка");
                        }
                    }

                }
            }
        }

        private void Add_Position(object sender, RoutedEventArgs e)
        {
            localdata.MainFrame.NavigationService.Navigate(new AdminPages.AdminCompAdd(localdata));
        }

        private void selected(object sender, MouseButtonEventArgs e)
        {
            if (mmm.SelectedItem != null)
            {
                localdata.Component = mmm.SelectedItem as Component;

                localdata.MainFrame.NavigationService.Navigate(new AdminPages.AdminCompOpened(localdata));
            }
        }
    }
}
