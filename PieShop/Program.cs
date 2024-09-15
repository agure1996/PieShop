using PieShopHRM;
using PieShopHRM.Accounting;
using PieShopHRM.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Will Add new employees into this list

List<Employee> employees = new List<Employee>();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\n*****************************");
Console.WriteLine("\n* Welcome to Gureggs Bakery *");
Console.WriteLine("\n*****************************");
Console.ForegroundColor = ConsoleColor.White;

string userSelection;
Console.ForegroundColor = ConsoleColor.Blue;
Utilities.CheckForExistingEmployeeFile();



do
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Loaded {employees.Count} employees\n\n");
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("*******************");
    Console.WriteLine("* Select   Action *");
    Console.WriteLine("*******************");


    Console.WriteLine("1. Register employee");
    Console.WriteLine("2. View all employees");
    Console.WriteLine("3. Save data");
    Console.WriteLine("4. Load data");
    Console.WriteLine("5. Load specific employee");
    Console.WriteLine("99. Quit application");
    Console.WriteLine("Your selection: ");

    userSelection = Console.ReadLine();

    switch (userSelection)
    {

        case "1":
            Utilities.RegisterEmployee(employees);
            break;
        case "2":
            Utilities.ViewAllEmployees(employees);
            break;
        case "3":
            Utilities.SaveEmployees(employees);
            break;
        case "4":
            Utilities.LoadEmployees(employees);
            break;
        case "5":
            Utilities.LoadEmployeeById(employees);
            break;
        case "99":
            break;
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
}
while (userSelection != "99");
Thread.Sleep(1200);
Console.WriteLine("Thanks for using the application");




