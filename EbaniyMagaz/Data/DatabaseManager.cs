using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaniyMagaz.Data
{
    public static class DatabaseManager
    {
        public static List<Component> Upload(string cmd)
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
                                Price = Convert.ToDouble(reader["Price"]),
                                ProductNumber = Convert.ToInt32(reader["Quantity"]),
                                ImagePath = reader["ImagePath"].ToString()

                            });
                        }
                    }
                    command.ExecuteNonQuery();
                }

                return components;

            }
        }
    }
}
