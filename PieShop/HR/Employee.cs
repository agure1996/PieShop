using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PieShopHRM.HR
{
    public class Employee : IEmployee
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int numberOfHoursWorked { get; set; }
        public int minimumHourWorked = 1;
        protected double taxRate = 1.25;
        public double wage { get; set; }
        public double hourlyRate;
        public double wallet { get; set; }

        private Address address { get; set; }
        public DateTime birthday { get; set; }


        /*
         * No Args constructor
         */
        public Employee() { }

        /*
        * All Args constructor
        */
        public Employee(string firstName, string lastName, string email, DateTime birthday, double? hourlyRate)
        {
            this.firstName = firstName; this.lastName = lastName;
            this.email = email; this.wage = wage;
            this.hourlyRate = hourlyRate.Value; this.birthday = birthday;
            this.numberOfHoursWorked = numberOfHoursWorked;
            this.wallet = wallet;
        }

        /**
         * Overloaded a new Employee constructor with address parameters
         */

        public Employee(string firstName, string lastName, string email, DateTime birthday, double? hourlyRate, string street, string houseNumber, string zipCode, string city)
        {
            this.firstName = firstName; this.lastName = lastName;
            this.email = email; this.wage = wage;
            this.hourlyRate = hourlyRate.Value; this.birthday = birthday;
            this.numberOfHoursWorked = numberOfHoursWorked;
            this.wallet = wallet;

            this.address = new Address(street, houseNumber, zipCode, city);
        }

        //public int GetNumberOfHoursWorked()
        //{
        //    return numberOfHoursWorked;
        //}


        public virtual void performWork()
        {
            //performed work but for minimum hr
            performWork(minimumHourWorked);
        }
        public virtual void performWork(int hours)
        {
            numberOfHoursWorked += hours;
            Console.WriteLine($"\n{firstName} {lastName} has worked {hours} hour(s)!");
        }
        public double receiveWage(bool resetHours = true)
        {

            double wageBeforeTax = numberOfHoursWorked * hourlyRate;
            double taxedAmount =  wageBeforeTax -(wageBeforeTax / taxRate);
            wage = wageBeforeTax - taxedAmount;
            wallet += wage;

            Console.WriteLine($"\n{firstName} {lastName} has received a total amount of  £{wage} for working {numberOfHoursWorked} hour(s)! \n");

            if (resetHours) numberOfHoursWorked = 0;



            return wage;
        }

        public string ConvertToJson()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(this);

            return json;
        }
        public void displayEmployeeDetails()
        {
            string employeedeets = $"\nFirstname: \t{firstName} \nSurname: \t{lastName} \nEmail Address: \t{email} \nDate of Birth: \t{birthday.ToShortDateString()} \nSalary: \t£{hourlyRate}'s per hour \nHours Worked: \t{numberOfHoursWorked} hour(s) \nWallet: \t£{wallet}";
            Console.WriteLine(employeedeets);
        }

        public double CalcBonusAndBonusTax()
        {   
         
          double bonus = 0;
            double BonusTax = 0;
          if (numberOfHoursWorked > 10) bonus = 200;

            if (bonus >= 200)
            {
                BonusTax = bonus / 10;
                bonus -= BonusTax;
                hourlyRate += bonus;
            }

            Console.WriteLine($"\nCongratulations Employee, you earned a bonus of £{bonus}, the tax on the bonus is £{BonusTax}");

            return bonus;
        }

        public virtual void giveBonus()
        {
            Console.WriteLine($"\nEmployee {firstName} {lastName} received a bonus of £120");
        }

        public void giveCompliment()
        {
            Console.WriteLine($"\nExcellent Work {firstName}! ~ Compliments from the Manager");
        }
    }
}
