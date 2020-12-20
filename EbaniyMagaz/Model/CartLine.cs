using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaniyMagaz.Model
{
    public class CartLine
    {
        public Component Component { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
    }
}
