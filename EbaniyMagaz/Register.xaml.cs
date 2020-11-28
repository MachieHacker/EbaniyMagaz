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
using System.Windows.Shapes;

namespace EbaniyMagaz
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using (MySqlConnection connection = new MySqlConnection(DataBase.connection))
            {
                connection.Open();
                if (textbox_register_login.Text != "" && textbox_register_email.Text != "" && passbox_register_pass.Password != "" && textbox_register_phone.Text != "" && textbox_register_firstname.Text != "" && textbox_register_secondname.Text != "")
                {
                    DataTable tbl = new DataTable();

                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users` WHERE `Login` = @US ", new MySqlConnection(DataBase.connection));
                    cmd.Parameters.Add("@US", MySqlDbType.VarChar).Value = textbox_register_login.Text;

                    adapter.SelectCommand = cmd;
                    adapter.Fill(tbl);

                    if (tbl.Rows.Count > 0)
                    {
                        label_register_warning4.Opacity = 100;
                    }
                    else
                    {
                        label_register_warning4.Opacity = 0;
                    }



                    if (passbox_register_pass.Password.Length < 8)
                    {
                        label_register_warning.Opacity = 100;
                    }
                    else
                    {
                        label_register_warning.Opacity = 0;
                    }

                    if (textbox_register_phone.Text.Length != 11)
                    {
                        label_register_warning2.Opacity = 100;
                    }
                    else
                    {
                        label_register_warning2.Opacity = 0;
                    }

                    if (!textbox_register_email.Text.Contains("@"))
                    {
                        label_register_warning3.Opacity = 100;
                    }   
                    else
                    {
                        label_register_warning3.Opacity = 0;
                    }


                    if (label_register_warning.Opacity != 100 && label_register_warning2.Opacity != 100 && label_register_warning3.Opacity != 100)
                    {
                        MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`Login`, `Password`, `Email`, `FirstName`, `LastName`, `PhoneNumber`) VALUES (@UL,@UP,@UE,@UFN,@ULN,@PN);", connection);
                        command.Parameters.Add("@UL", MySqlDbType.VarChar).Value = textbox_register_login.Text;
                        command.Parameters.Add("@UP", MySqlDbType.VarChar).Value = passbox_register_pass.Password;
                        command.Parameters.Add("@UE", MySqlDbType.VarChar).Value = textbox_register_email.Text;
                        command.Parameters.Add("@UFN", MySqlDbType.Text).Value = textbox_register_firstname.Text;
                        command.Parameters.Add("@ULN", MySqlDbType.Text).Value = textbox_register_secondname.Text;
                        command.Parameters.Add("@PN", MySqlDbType.Text).Value = textbox_register_phone.Text;

                        command.ExecuteNonQuery();



                        this.Hide();
                        MainWindow main = new MainWindow();
                        main.ShowDialog();
                        this.Close();
                    }


                }

                else
                {
                    MessageBox.Show("Введите данные");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.ShowDialog();
            this.Close();
        }
    }
    }
