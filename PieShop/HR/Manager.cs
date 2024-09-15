using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopHRM.HR
{
    internal class Manager : Employee
    {
        public Manager(string firstName, string lastName, string email, DateTime birthday, double? hourlyRate) : base(firstName, lastName, email, birthday, hourlyRate){}
        public void AttendManagementMeeting()
        {
            numberOfHoursWorked += 10;
            Console.WriteLine($"\nManager - {firstName} {lastName} has worked {numberOfHoursWorked} hour(s) attending meetings!");

        }

        public override void performWork()
        {
            numberOfHoursWorked += 2;
            Console.WriteLine($"\nManager - {firstName} {lastName} has worked {numberOfHoursWorked} hour(s)!");
        }

        public override void giveBonus()
        {
            if (numberOfHoursWorked > 5) {
                Console.WriteLine($"\nManager {firstName} {lastName} received a bonus of £220"); 
            } 
            else Console.WriteLine($"\n{firstName} {lastName} received a bonus of £150");
        }
    }

}

