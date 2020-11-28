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

namespace EbaniyMagaz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void button_login_Click(object sender, EventArgs e)
        //{
        //    String LoginUser = textBox_login.Text;
        //    String PassUser = textBox_password.Text;

        //    DataTable table = new DataTable();

        //    MySqlDataAdapter adapter = new MySqlDataAdapter();

        //    MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Login` = @US AND `Password` = @UP ", new MySqlConnection(DataBase.connection));
        //    command.Parameters.Add("@US", MySqlDbType.VarChar).Value = LoginUser;
        //    command.Parameters.Add("@UP", MySqlDbType.VarChar).Value = PassUser;

        //    adapter.SelectCommand = command;
        //    adapter.Fill(table);


        //    if (textBox_login.Text != "" && textBox_password.Text != "")
        //    {
        //        if (table.Rows.Count == 0)
        //        {
        //            MessageBox.Show("Проверьте правильность введенных данных");
        //            textBox_login.Text = "";
        //            textBox_password.Text = "";
        //        }
        //        else
        //        {
        //            this.Hide();
        //            Store store = new Store();
        //            store.ShowDialog();
        //            this.Close();
        //        }

        //    }

        //    else
        //    {
        //        MessageBox.Show("Введите данные");
        //    }

        //}


        //private void button_register_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    Register register = new Register();
        //    register.ShowDialog();
        //    this.Close();

        //}

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Login` = @US AND `Password` = @UP ", new MySqlConnection(DataBase.connection));
            command.Parameters.Add("@US", MySqlDbType.VarChar).Value = textbox_login.Text;
            command.Parameters.Add("@UP", MySqlDbType.VarChar).Value = textbox_pass.Password;

            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (textbox_login.Text != "" && textbox_pass.Password != "")
            {
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Проверьте правильность введенных данных");
                    textbox_login.Text = "";
                    textbox_pass.Password = "";
                }
                else
                {
                    this.Hide();
                    Store store = new Store();
                    store.Show();
                    this.Close();
                }

            }

            else
            {
                MessageBox.Show("Введите данные");
            }
        }

        private void button_register_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
            this.Close();
        }
    }
}
