using EbaniyMagaz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EbaniyMagaz
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public Cart(List<CartLine> lineCollection)
        {
            this.lineCollection = lineCollection;
        }

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

        public float ComputeTotalValue()
        {
            return lineCollection.Sum(e => Convert.ToInt32(e.Component.Price) * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public List<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
}
