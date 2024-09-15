using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopHRM.HR
{
    internal class Address
    {
        private string street { get; set; }
        private string houseNumber { get; set; }
        private string zipCode { get; set; }
        private string city{ get; set; }
        public Address(string street,string houseNumber, string zipCode, string city) {

            this.street = street;
            this.houseNumber = houseNumber;
            this.zipCode = zipCode;
            this.city = city;
        }    


    }
}
