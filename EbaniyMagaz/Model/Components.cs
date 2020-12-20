using EbaniyMagaz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaniyMagaz
{
    public class Component
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Specification { get; set; }
        public double Price { get; set; }
        public int ProductNumber { get; set; }
        public ProductType ProductType { get; set; }
        public string ImagePath { get; set; }
    }
}
