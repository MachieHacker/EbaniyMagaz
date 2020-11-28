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

        public Opened(LocalData localdata)
        {
            this.localdata = localdata;
            InitializeComponent();

            this.Loaded += Opened_Loaded;
            
        }

        private void Opened_Loaded(object sender, RoutedEventArgs e)
        {
            lb.Content = this.localdata.Component.Model;
            lb_spec.Content = this.localdata.Component.Specification;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            localdata.MainFrame.NavigationService.GoBack();
        }
    }
}
