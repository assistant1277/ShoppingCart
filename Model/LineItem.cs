using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Model
{
    public class LineItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public LineItem(int id, Product product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }

        //method to calculate total cost of line item means -> quantity*price after discount 
        public double CalculateLineItemCost()
        {
            return Quantity*Product.CalculateDiscountedPrice();
        }
    }
}
