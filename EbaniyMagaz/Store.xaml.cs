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
using System.Windows.Shapes;

namespace EbaniyMagaz
{
    /// <summary>
    /// Логика взаимодействия для Store.xaml
    /// </summary>
    public partial class Store : Window
    {
        public Store()
        {
            InitializeComponent();
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new HomePageStore(new LocalData() { MainFrame = frame}));
        }

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Pages.Processors(new LocalData() { MainFrame = frame }));
        }

        private void frame_Loaded(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new HomePageStore(new LocalData() { MainFrame = frame }));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Pages.CartPage());
        }
    }
}
