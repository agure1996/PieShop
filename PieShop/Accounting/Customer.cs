using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopHRM.Accounting
{
    internal class Customer
    {

        private string customerId;
        private string customerName;

        public string CustomerId { get => customerId; set => customerId = value; }

        public string CustomerName { get => customerName;  set =>  customerName = value; }

    }
}
