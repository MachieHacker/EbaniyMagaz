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
    /// Логика взаимодействия для AdminOpened.xaml
    /// </summary>
    public partial class AdminOpened : Page
    {
        private LocalData localdata;
        public AdminOpened(LocalData localdata)
        {
            this.localdata = localdata;
            InitializeComponent();

            this.Loaded += AdminOpened_Loaded;
        }

        private void AdminOpened_Loaded(object sender, RoutedEventArgs e)
        {
            OP_login.Text = localdata.User.Login;
            OP_pswd.Text = localdata.User.Password;
            OP_email.Text = localdata.User.Email;
            OP_phone.Text = localdata.User.PhoneNumber;
            OP_FN.Text = localdata.User.FirstName;
            OP_LN.Text = localdata.User.LastName;
        }

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(DataBase.connection))
            {
                List<Component> components = new List<Component>();
                connection.Open();

                string cmd = "UPDATE `users` SET `Login`=@LG,`Password`=@PSW,`Email`=@EM,`FirstName`=@FN,`LastName`=@LN,`PhoneNumber`=@PN WHERE `id` = @ID";

                using (MySqlCommand command = new MySqlCommand(cmd, connection))
                {
                    command.Parameters.Add("@ID", MySqlDbType.VarChar).Value = localdata.User.Id;
                    command.Parameters.Add("@LG", MySqlDbType.VarChar).Value = OP_login.Text;
                    command.Parameters.Add("@PSW", MySqlDbType.VarChar).Value = OP_pswd.Text;
                    command.Parameters.Add("@EM", MySqlDbType.VarChar).Value = OP_email.Text;
                    command.Parameters.Add("@FN", MySqlDbType.VarChar).Value = OP_FN.Text;
                    command.Parameters.Add("@LN", MySqlDbType.VarChar).Value = OP_LN.Text;
                    command.Parameters.Add("@PN", MySqlDbType.VarChar).Value = OP_phone.Text;


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
