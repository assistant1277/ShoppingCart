using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<LineItem> Items { get; set; } //initialized empty list of line items

        public Order(int id, DateTime date)
        {
            Id = id;
            Date = date;
            Items = new List<LineItem>();
        }

        //method to calculate total cost of order by summing up cost of all line items
        public double CalculateOrderPrice()
        {
            double totalCost = 0;
            foreach (var item in Items)
            {
                totalCost += item.CalculateLineItemCost(); //add cost of each item
            }
            return totalCost;
        }
    }
}
