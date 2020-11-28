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
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public List<Component> Cartlist;

        public CartPage(List<Component> cartlist)
        {
            InitializeComponent();
            this.Cartlist = cartlist;
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

        //public class CartLogic
        //{
        //    List<CartLine> lineCollection = new List<CartLine>();

        //    public void AddItem(Component component, int quantity)
        //    {
        //        CartLine line = lineCollection
        //            .Where(p => p.Component.Id == component.Id)
        //            .FirstOrDefault();

        //        if (line == null)
        //        {
        //            lineCollection.Add(new CartLine
        //            {
        //                Component = component,
        //                Quantity = quantity
        //            });
        //        }
        //        else
        //        {
        //            line.Quantity += quantity;
        //        }
        //    }

        //    public void RemoveLine(Component component)
        //    {
        //        lineCollection.RemoveAll(l => l.Component.Id == component.Id);
        //    }

        //    public decimal ComputeTotalValue()
        //    {
        //        return lineCollection.Sum(e => Convert.ToInt32(e.Component.Price) * e.Quantity);

        //    }
        //    public void Clear()
        //    {
        //        lineCollection.Clear();
        //    }

        //    public IEnumerable<CartLine> Lines => lineCollection;
        //}
    }
}

