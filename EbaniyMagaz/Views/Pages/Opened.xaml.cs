using EbaniyMagaz.Data;
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
    /// Логика взаимодействия для Opened.xaml
    /// </summary>
    public partial class Opened : Page
    {
        private LocalData localdata;

        public Component Component { get; set; }

        public Opened(LocalData localdata)
        {
            this.localdata = localdata;
            InitializeComponent();
            this.DataContext = this;
            Component = localdata.Component;

            this.Loaded += Opened_Loaded;
            
        }

        private void Opened_Loaded(object sender, RoutedEventArgs e)
        {
            lb.Text = this.localdata.Component.Model;
            lb_spec.Text = this.localdata.Component.Specification;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            localdata.MainFrame.NavigationService.GoBack();
        }

        private void Button_buy_Click(object sender, RoutedEventArgs e)
        {
            if (localdata.Component != null && localdata.Component.ProductNumber != 0)
            {
                localdata.CartObject.AddItem(localdata.Component, Convert.ToInt32(Quant_label.Content));

                MessageBox.Show("Товар добавлен в корзину");
            }
            else
            {
                MessageBox.Show("Товара нет в наличии");
            }

            
        }

        private int counter = 1;
        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            Quant_label.Content = counter;
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (counter > 1 )
            {
                counter--;
                Quant_label.Content = counter;
            }
        }
    }
}
