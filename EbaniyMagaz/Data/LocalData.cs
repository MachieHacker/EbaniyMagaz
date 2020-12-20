using EbaniyMagaz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EbaniyMagaz
{
    public class LocalData
    {
        public Frame MainFrame { get; set; }

        public Component Component { get; set; }

        public User User { get; set; }

        public Cart CartObject { get; set; }

        public ProductType ProductType { get; set; }
    }
}
