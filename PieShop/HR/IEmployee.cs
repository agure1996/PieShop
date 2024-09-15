using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopHRM.HR
{
    internal interface IEmployee
    {
        double receiveWage(bool resetHrs = true);

        void giveBonus();

        void performWork();

        void performWork(int NumberOfHours);

        void displayEmployeeDetails();

        void giveCompliment();

    }
}
