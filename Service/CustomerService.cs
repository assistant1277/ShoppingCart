using ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Service
{
    public static class CustomerService
    {
        //method creates sample customers with orders and returns them as list
        public static List<Customer> GetCustomersWithOrders()
        {
            //create three products with id,name,price,discount
            Product product1 = new Product(1,"laptop",1000,10); 
            Product product2 = new Product(2,"mobile",500,5); 
            Product product3 = new Product(3,"keyboard",100,15);

            //create line items order details for products
            LineItem item1 = new LineItem(1,product1,1); //1 laptop
            LineItem item2 = new LineItem(2,product2,2); //2 mobiles
            LineItem item3 = new LineItem(3,product3,3); //3 keyboards
            LineItem item4 = new LineItem(4,product2,4); //4 more mobiles

            //create two orders with different dates
            Order order1 = new Order(1, DateTime.Now.AddDays(-10));//order 1 10 days ago and DateTime.Now returns current date and time on local system/pc
            order1.Items.Add(item1);//add laptop
            order1.Items.Add(item2);//add 2 mobiles
            Order order2 = new Order(2, DateTime.Now.AddDays(-5)); //and assume if DateTime.Now.AddDays(5) means 5 day ahead/forward
            order2.Items.Add(item3); //add 3 keyboards
            order2.Items.Add(item4); //add 4 mobiles

            //create customer and add two orders
            Customer customer = new Customer(12345,"raj");
            customer.Orders.Add(order1);
            customer.Orders.Add(order2);

            //return list of customers just one customer here
            return new List<Customer> { customer };
        }
    }
}
