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
        private List<Component> cartlist;

        public CartPage(LocalData localData)
        {
            InitializeComponent();

            this.localData = localData;
            this.cartlist = localData.CartList;
        }

        //private List<Component> Upload(string cmd)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(DataBase.connection))
        //    {
        //        List<Component> components = new List<Component>();
        //        connection.Open();

        //        using (MySqlCommand command = new MySqlCommand(cmd, connection))
        //        {
        //            using (MySqlDataReader reader = command.ExecuteReader())
        //            {

        //                while (reader.Read())
        //                {
        //                    components.Add(new Component()
        //                    {
        //                        Id = Convert.ToInt32(reader["ProductId"]),
        //                        Manufacturer = reader["Manufacturer"].ToString(),
        //                        Model = reader["Model"].ToString(),
        //                        Specification = reader["Specifications"].ToString(),
        //                        Price = reader["Price"].ToString()

        //                    });
        //                }
        //            }
        //            command.ExecuteNonQuery();
        //        }
        //        return components;

        //    }
        //}

        private void Cart_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

