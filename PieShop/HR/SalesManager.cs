using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopHRM.HR
{
    internal class SalesManager : Manager
    {
        public SalesManager(string firstName, string lastName, string email, DateTime birthday, double? hourlyRate) : base(firstName, lastName, email, birthday, hourlyRate)
        {
        }
    }
}
