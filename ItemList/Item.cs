using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace ItemList
{

    public enum Unit
    {
        Box,
        Piece,
        Palette,
    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public Unit Unit { get; set; }

        public Item(){

        }

        public Item(string name = "", string details = "", double amount = 0, int quantity = 0, Unit unit = Unit.Piece)
        {
            Id = 
            Name = name;
            Details = details;
            Amount = amount;
            Quantity = quantity;
            Unit = unit;
        }

        public override string ToString()
        {
            return (this.Name + " " + this.Quantity.ToString() + " " + this.Unit.ToString()).Trim() ;
        }
    }
}
