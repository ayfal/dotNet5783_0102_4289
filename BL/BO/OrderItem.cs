using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString() => $@"
        Order ID: {ID}
       ProductId: {ProductId}
    	Name: {Name}
        Price: {Price}
        Amount: {Amount}
        TotalPrice: {TotalPrice}
";
    }
}
