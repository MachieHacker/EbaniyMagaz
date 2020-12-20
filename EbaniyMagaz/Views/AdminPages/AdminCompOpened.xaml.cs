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
    /// Логика взаимодействия для AdminCompOpened.xaml
    /// </summary>
    public partial class AdminCompOpened : Page
    {
        private LocalData localdata;
        public AdminCompOpened(LocalData localdata)
        {
            this.localdata = localdata;
            InitializeComponent();

            this.Loaded += AdminCompOpened_Loaded;
        }

        private void AdminCompOpened_Loaded(object sender, RoutedEventArgs e)
        {
            OP_mnf.Text = localdata.Component.Manufacturer;
            OP_model.Text = localdata.Component.Model;
            OP_spec.Text = localdata.Component.Specification;
            OP_price.Text = localdata.Component.Price.ToString();
            OP_quan.Text = localdata.Component.ProductNumber.ToString();
            OP_image.Text = localdata.Component.ImagePath;
        }

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(DataBase.connection))
            {
                List<Component> components = new List<Component>();
                connection.Open();

                string cmd = "UPDATE `" + localdata.ProductType.ToString() + "` SET `Manufacturer`=@MNF,`Model`=@MD,`Specification`=@SPC,`Price`=@PR,`Quantity`=@QU,`ImagePath`=@IMG WHERE `ID` = @ID";

                using (MySqlCommand command = new MySqlCommand(cmd, connection))
                {
                    command.Parameters.Add("@ID", MySqlDbType.VarChar).Value = localdata.Component.Id;
                    command.Parameters.Add("@MNF", MySqlDbType.VarChar).Value = OP_mnf.Text;
                    command.Parameters.Add("@MD", MySqlDbType.VarChar).Value = OP_model.Text;
                    command.Parameters.Add("@SPC", MySqlDbType.VarChar).Value = OP_spec.Text;
                    command.Parameters.Add("@PR", MySqlDbType.VarChar).Value = OP_price.Text;
                    command.Parameters.Add("@QU", MySqlDbType.Int32).Value = OP_quan.Text;
                    command.Parameters.Add("@IMG", MySqlDbType.VarChar).Value = OP_image.Text;

                    command.ExecuteNonQuery();
                }


            }
            MessageBox.Show("Изменения внесены");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            localdata.MainFrame.NavigationService.GoBack();
        }
    }
}
