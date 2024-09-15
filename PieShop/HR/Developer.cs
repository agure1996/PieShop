using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopHRM.HR
{
    public class Developer:Employee
    {

        private string? currentProject { get; set; }

        public Developer(string firstName, string lastName, string email, DateTime birthday, double? hourlyRate, string? currentProject) : base(firstName, lastName, email, birthday, hourlyRate)
        {
        }

        public Developer()
        {
        }

        public Developer(string firstName, string lastName, string email, DateTime birthday, double? hourlyRate) : base(firstName, lastName, email, birthday, hourlyRate)
        {
        }

        public override void giveBonus()
        {
            if (numberOfHoursWorked > 5)
            {
                Console.WriteLine($"\nEmployee {firstName} {lastName} received a bonus of £180");
            }
            else Console.WriteLine($"\nEmployee {firstName} {lastName} received a bonus of £110");
        }

    }
}
