using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopHRM.HR
{
    internal struct WorkTask
    {
        public string description;
        public int hrs;

        public void performWorkTask()
        {
            Console.WriteLine($"\n{description} task has been performed for {hrs} hr(s)");
        }
    }
}
