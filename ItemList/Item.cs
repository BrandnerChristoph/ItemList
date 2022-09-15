using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemList
{

    public enum Unit
    {

    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

    }
}
