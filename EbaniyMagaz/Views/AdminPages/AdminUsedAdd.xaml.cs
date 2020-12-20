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
    /// Логика взаимодействия для AdminUsedAdd.xaml
    /// </summary>
    public partial class AdminUsedAdd : Page
    {
        private LocalData localdata;
        public AdminUsedAdd(LocalData localdata)
        {
            InitializeComponent();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            localdata.MainFrame.NavigationService.GoBack();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (OP_login.Text != "" && OP_pswd.Text != "" && OP_email.Text != "" && OP_phone.Text != "" && OP_FN.Text != "" && OP_LN.Text != "")
            {
                using (MySqlConnection connection = new MySqlConnection(DataBase.connection))
                {
                    List<Component> components = new List<Component>();
                    connection.Open();

                    string cmd = "INSERT INTO `users` (`Id`, `Login`, `Password`, `Email`, `FirstName`, `LastName`, `PhoneNumber`) VALUES(NULL, @UL,@UP,@UE,@UFN,@ULN,@PN);";

                    using (MySqlCommand command = new MySqlCommand(cmd, connection))
                    {

                        command.Parameters.Add("@UL", MySqlDbType.VarChar).Value = OP_login.Text;
                        command.Parameters.Add("@UP", MySqlDbType.VarChar).Value = OP_pswd.Text;
                        command.Parameters.Add("@UE", MySqlDbType.VarChar).Value = OP_email.Text;
                        command.Parameters.Add("@UFN", MySqlDbType.VarChar).Value = OP_phone.Text;
                        command.Parameters.Add("@ULN", MySqlDbType.Int32).Value = OP_FN.Text;
                        command.Parameters.Add("@PN", MySqlDbType.Int32).Value = OP_LN.Text;

                        command.ExecuteNonQuery();

                        MessageBox.Show("Аккаунт добавлен");

                    }

                }
            }


        }
    }
}
