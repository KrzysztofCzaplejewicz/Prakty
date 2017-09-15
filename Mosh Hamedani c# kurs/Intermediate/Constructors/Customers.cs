using System.Collections.Generic;

namespace Constructors
{
    public class Customers
    {
        public string Name;
        public int Id;
        public List<Order> Orders;

        public Customers()
        {
            Orders = new List<Order>();
        }

        public Customers(int id)
            : this()
        {
            this.Id = id;
        }

        public Customers(int id, string name)
            : this(id)
        {
            this.Name = name;
        }
    }
}