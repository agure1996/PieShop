using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopHRM.HR
{
    internal class Researcher : Employee
    {
        private int numberOfPiesInvented = 0;

        public Researcher(string firstName, string lastName, string email, DateTime birthday, double? hourlyRate) : base(firstName, lastName, email, birthday, hourlyRate)
        {
        }

        public Researcher(string firstName, string lastName, string email, DateTime birthday, double? hourlyRate, int numberOfPiesInvented) : base(firstName, lastName, email, birthday, hourlyRate)
        {
        }

        public int NumberOfPieTastesInvented
        {

            get { return numberOfPiesInvented; }
            private set
            {
                numberOfPiesInvented = value;

            }
        }

        public void researchNewPie(int researchHrs)
        {
            numberOfHoursWorked += researchHrs;

            if(new Random().Next(100) > 60)
            {
                numberOfPiesInvented++;
                Console.WriteLine("\n. . . ");
                Thread.Sleep(1000);
                Console.WriteLine($"\nResearcher {firstName} {lastName} has Invented a new Pie! Total number of pies invented {numberOfPiesInvented}");
            }
            else Console.WriteLine($"\nResearcher {firstName} {lastName} still working on new recipe...");
        }
    }
}
