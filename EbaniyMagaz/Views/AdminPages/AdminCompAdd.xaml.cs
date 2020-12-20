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

namespace EbaniyMagaz.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminCompAdd.xaml
    /// </summary>
    public partial class AdminCompAdd : Page
    {
        LocalData localdata;
        public AdminCompAdd(LocalData localdata)
        {
            this.localdata = localdata;
            InitializeComponent();
        }  

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            localdata.MainFrame.NavigationService.GoBack();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            if (OP_mnf.Text != "" && OP_model.Text != "" && OP_price.Text != "" && OP_quan.Text != "" && OP_spec.Text != "" && OP_image.Text != "")
            {
                using (MySqlConnection connection = new MySqlConnection(DataBase.connection))
                {
                    List<Component> components = new List<Component>();
                    connection.Open();

                    string cmd = "INSERT INTO " + localdata.ProductType.ToString() + " (`Id`, `Manufacturer`, `Model`, `Specification`, `Price`, `Quantity`, `ProductType`, `ImagePath`) VALUES (NULL, @MNF, @MD, @SPC, @PR, @QU, '',@IMG)";

                    using (MySqlCommand command = new MySqlCommand(cmd, connection))
                    {

                            command.Parameters.Add("@MNF", MySqlDbType.VarChar).Value = OP_mnf.Text;
                            command.Parameters.Add("@MD", MySqlDbType.VarChar).Value = OP_model.Text;
                            command.Parameters.Add("@SPC", MySqlDbType.VarChar).Value = OP_spec.Text;
                            command.Parameters.Add("@PR", MySqlDbType.VarChar).Value = OP_price.Text;
                            command.Parameters.Add("@QU", MySqlDbType.Int32).Value = OP_quan.Text;
                            command.Parameters.Add("@IMG", MySqlDbType.VarChar).Value = OP_image.Text;

                            command.ExecuteNonQuery();

                            MessageBox.Show("Товар добавлен");

                    }

                }
            }

            else
            {
                MessageBox.Show("Введите все данные");
            }
            
            
        }
    }
}
