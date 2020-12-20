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
    /// Логика взаимодействия для TabelUsers.xaml
    /// </summary>
    public partial class TabelUsers : Page
    {
        private LocalData localdata;
        public TabelUsers(LocalData localdata)
        {
            this.localdata = localdata;
            InitializeComponent();

            this.Loaded += TabelUsers_Loaded;
            
        }

        private void TabelUsers_Loaded(object sender, RoutedEventArgs e)
        {
            mmm.ItemsSource = Upload("SELECT * FROM  users");
        }

        private List<User> Upload(string cmd)
        {
            using (MySqlConnection connection = new MySqlConnection(DataBase.connection))
            {
                List<User> users = new List<User>();
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(cmd, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            users.Add(new User()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Login = reader["Login"].ToString(),
                                Password = reader["Password"].ToString(),
                                Email = reader["Email"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString()

                            });
                        }
                    }
                    command.ExecuteNonQuery();
                }
                return users;

            }
        }

        private void selected(object sender, MouseButtonEventArgs e)
        {

            if (mmm.SelectedItem != null)
            {
                localdata.User = mmm.SelectedItem as User;

                localdata.MainFrame.NavigationService.Navigate(new AdminPages.AdminOpened(localdata));
            }
        }

        private void Add_Position(object sender, RoutedEventArgs e)
        {
            localdata.MainFrame.NavigationService.Navigate(new AdminPages.AdminUsedAdd(localdata));
        }

        private void Delete_Position(object sender, RoutedEventArgs e)
        {
            User item = mmm.SelectedItem as User;

            if (item != null)
            {
                using (MySqlConnection connection = new MySqlConnection(DataBase.connection))
                {
                    List<Component> components = new List<Component>();
                    connection.Open();

                    string cmd = "DELETE FROM `users`  WHERE `Id` = @ID";

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
    }
}
