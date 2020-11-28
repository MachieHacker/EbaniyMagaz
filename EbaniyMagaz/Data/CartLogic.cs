using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EbaniyMagaz
{
    public class CartLogic
    {
        public class Cart
        {
            private List<CartLine> lineCollection = new List<CartLine>();

            public void AddItem(Component component, int quantity)
            {
                CartLine line = lineCollection
                    .Where(p => p.Component.Id == component.Id)
                    .FirstOrDefault();

                if (line == null)
                {
                    lineCollection.Add(new CartLine
                    {
                        Component = component,
                        Quantity = quantity
                    });
                }
                else
                {
                    line.Quantity += quantity;
                }
            }

            public void RemoveLine(Component component)
            {
                lineCollection.RemoveAll(l => l.Component.Id == component.Id);
            }

            public decimal ComputeTotalValue()
            {
                return lineCollection.Sum(e => Convert.ToInt32(e.Component.Price) * e.Quantity);

            }
            public void Clear()
            {
                lineCollection.Clear();
            }

            public IEnumerable<CartLine> Lines
            {
                get { return lineCollection; }
            }
        }

        public class CartLine
        {
            public Component Component { get; set; }
            public int Quantity { get; set; }
            public Frame MainFrame { get; set; }
        }
    }
}
