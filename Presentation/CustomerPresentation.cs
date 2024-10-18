using ShoppingCart.Model;
using ShoppingCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShoppingCart.Presentation
{
    public static class CustomerPresentation
    {
        public static void DisplayCustomerOrders()
        {
            Console.WriteLine("***** Welcome to Shopping_Cart app *****\n");

            //get list of customers with their orders
            var customers = CustomerService.GetCustomersWithOrders();

            //loop through each customer
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer Id -> {customer.Id}");
                Console.WriteLine($"Customer Name -> {customer.Name}");
                Console.WriteLine($"Order Count -> {customer.Orders.Count}");//customer.Orders refers to list of orders that customer has made and Count tells you how many orders are in list

                //loop through each order of customer
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"\nOrder No -> {order.Id}");
                    Console.WriteLine($"Order Id -> {order.Id}");

                    //ToShortDateString() is method that converts full date and time to just date part like 18-10-2024
                    Console.WriteLine($"Order Date -> {order.Date.ToShortDateString()}\n"); //order.Date refers to date when order was placed

                    Console.WriteLine("LineItemId  ProductId  ProductName  Quantity  UnitPrice  Discount%  UnitCostAfterDiscount  TotalLineItemCost");

                    //loop through each line item means product in order
                    foreach (var item in order.Items)
                    {
                        //calculate discounted price and total cost for each line item
                        double discountedPrice = item.Product.CalculateDiscountedPrice();
                        double lineCost = item.CalculateLineItemCost();

                        //in {item.Id,6} here 6 means we want this to take up 6 spaces if it is shorter it will align to right and 
                        //{item.Product.Id,11} here 11 means it will take up 11 spaces right aligned
                        // {item.Product.Name,13} here 13 means we want it to take up 13 spaces so longer names fit nicely
                        //{item.Product.Price,11} here 11 means it will take up 11 spaces for formatting
                        //and if assume i put {item.Product.Id,-11} it will move content back to left side means shift space backward
                        //in short we are doing formatting
                        Console.WriteLine($"{item.Id,6} {item.Product.Id,11} {item.Product.Name,13} {item.Quantity,7} {item.Product.Price,11} {item.Product.DiscountPercent,9} {discountedPrice,16} {lineCost,20}");
                    }

                    double totalOrderCost = order.CalculateOrderPrice();

                    //print row of dashes and number 110 means the dashes will be centered in space that is 110 characters means wide means dashes will be centered nice
                    Console.WriteLine($"\n{"-------------------",110}");

                    //this line print "Order cost ->" followed by total cost of order
                    //it uses string interpolation to format output
                    //"Order cost ->" will be left aligned and will take 104 spaces
                    //ensures that there is enough space for total order cost to right aligned after it
                    Console.WriteLine($"{"Order cost ->",104} {totalOrderCost}\n");
                }
            }
        }
    }
}
