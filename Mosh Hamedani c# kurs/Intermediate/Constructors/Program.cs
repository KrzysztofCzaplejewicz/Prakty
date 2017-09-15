using System;
using System.Threading;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customers(1, "JOHN");
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.Name);
            Thread.Sleep(2000);
            var order = new Order();
            customer.Orders.Add(order);
        }
    }
}
