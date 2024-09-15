using PieShopHRM.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopHRM
{
    internal class Utilities
    {

        //private static string directory = @"C:\Users\dell\Desktop\Projects\VS Code Projects\csharp\PieShop\data\";
        //private static string filename = @"Employees.txt";

        // Use relative path for 'data' folder within the project directory

        private static string directory = Path.Combine(Directory.GetCurrentDirectory(), "data");
        private static string filename = Path.Combine(directory, @$"\Employees.txt");

        internal static void RegisterEmployee(List<Employee> employees)
        {
            Console.WriteLine("Creating Employee . . .");
            Thread.Sleep(1000);
            Console.WriteLine("What type of employee do you wish to register?");
            Console.WriteLine("1. Employee\n2. Manager\n3. Sales manager\n4. Researcher\n5. Developer");
            Console.WriteLine("Your Selection: ");
            string employeeType = Console.ReadLine();

            string firstName, lastName, email;

            if (employeeType != "1" && employeeType != "2" && employeeType != "3" && employeeType != "4" && employeeType != "5")
            {
                Console.WriteLine("Invalid Selection, Try Again . . .");
                return;
            }

            Console.WriteLine("Enter the first name: ");
             firstName = Console.ReadLine();

            Console.WriteLine("Enter the last name: ");
             lastName = Console.ReadLine();

            Console.WriteLine("Enter the email: ");
             email = Console.ReadLine();

            Console.WriteLine("Enter your birthday: ");
            DateTime birthday = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the hourly rate: ");
            string hourlyRate = Console.ReadLine();

            double rate = double.Parse(hourlyRate);

            Employee? employee = null;

            switch (employeeType)
            {

                case "1":
                    employee = new Employee(firstName, lastName, email, birthday, rate);
                    break;
                case "2":
                    employee = new Manager(firstName, lastName, email, birthday, rate);
                    break;
                case "3":
                    employee = new SalesManager(firstName, lastName, email, birthday, rate);
                    break;
                case "4":
                    employee = new Researcher(firstName, lastName, email, birthday, rate, 0);
                    break;
                case "5":
                    employee = new Developer(firstName, lastName, email, birthday, rate);
                    break;
            }

            employees.Add(employee);

            Console.WriteLine("Employee created!\n\n");

        }
        internal static void ViewAllEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                employees[i].displayEmployeeDetails();
            }
           
            }

        internal static void LoadEmployees(List<Employee> employees)
        {
            string completePath = $"{directory}{filename}";
            try
            {
                if (File.Exists(completePath))
                {
                    employees.Clear();

                    //Now read the file
                    string[] employeesAsString = File.ReadAllLines(completePath);

                    for (int i = 0; i < employeesAsString.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine($"\nEmployee ID: {i}");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        string[] split = employeesAsString[i].Split(';');
                        string firstName = split[0].Substring(split[0].IndexOf(':') + 1);
                        string lastName = split[1].Substring(split[1].IndexOf(':') + 1);
                        string email = split[2].Substring(split[2].IndexOf(':') + 1);
                        string parseDate = split[3].Substring(split[3].IndexOf(':') + 1);
                        DateTime birthday = DateTime.ParseExact(parseDate,"dd MM yyyy",null);
                        double rate = double.Parse(split[4].Substring(split[4].IndexOf(':') + 1));
                        string employeeType = split[5].Substring(split[5].IndexOf(':') + 1);

                        Employee? employee = null;

                        switch (employeeType)
                        {
                            case "1":
                                employee = new Employee(firstName, lastName, email, birthday, rate);
                                break;
                            case "2":
                                employee = new Manager(firstName, lastName, email, birthday, rate);
                                break;
                            case "3":
                                employee = new SalesManager(firstName, lastName, email, birthday, rate);
                                break;
                            case "4":
                                employee = new Researcher(firstName, lastName, email, birthday, rate);
                                break;
                            case "5":
                                employee = new Developer(firstName, lastName, email, birthday, rate);
                                break;
                            default:
                                Console.WriteLine($"Unknown employee type: {employeeType}. Skipping this entry.");
                                continue;
                        }

                        employees.Add(employee);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nLoaded {employees.Count} employee(s)!\n\n");
                    Console.ResetColor();
                }
            }
            catch (FileNotFoundException fnfex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File could not be found!\n\n");
                Console.WriteLine(fnfex.Message);
                Console.WriteLine(fnfex.StackTrace);
                
            }
            catch (IndexOutOfRangeException ioorex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ioorex.Message);
                Console.WriteLine("Index of one of the parameters loaded doesn't exist in the range its split!\n\n");
                
            }
            finally { Console.ResetColor(); }
        }

        internal static void LoadEmployeeById(List<Employee> employees)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\nEnter employee ID you want: ");
            try{
                int selectedId = int.Parse(Console.ReadLine()); 
                Employee selectedEmployee = employees[selectedId];
                selectedEmployee.displayEmployeeDetails();
            } catch(FormatException fex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(fex.Message);
                Console.WriteLine("Incorrect format, please input a number!\n\n");
               
            } catch(ArgumentOutOfRangeException outOfRangeEx)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(outOfRangeEx.Message);
                Console.WriteLine("Argument out of range means ID doesn't exist in current size of employee list!\n\n");
               
            }
            finally { Console.ResetColor(); }
        }
        internal static void SaveEmployees(List<Employee> employees)
        {
            string completePath = $"{directory}{filename}";
            StringBuilder sb = new StringBuilder();
            foreach (Employee employee in employees)
            {   
                string type = GetEmployeeType(employee);
                sb.Append($"First name:{employee.firstName};");
                sb.Append($"Last name:{employee.lastName};");
                sb.Append($"email:{employee.email};");
                sb.Append($"DOB:{employee.birthday.ToString("dd MM yyyy")};");
                sb.Append($"Hourly rate:{employee.hourlyRate};");
                sb.Append($"type:{type}");
                sb.Append(Environment.NewLine);
           
            }
            try
            {

            File.WriteAllText(completePath, sb.ToString());
            }
            catch(IOException ioe)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Filename or directory name could be wrong, check path of directory or file!\n\n");
                Console.WriteLine(ioe.Message);
                Console.WriteLine(ioe.StackTrace);
            } 
        }

        private static string GetEmployeeType(Employee employee)
        {
            if (employee is Employee) return "1";
            if (employee is Manager) return "2";
            if (employee is SalesManager) return "3";
            if (employee is Researcher) return "4";
            if (employee is Developer) return "5";

            return "0";
        }
        internal static void CheckForExistingEmployeeFile()
        {
            string completePath = $"{directory}{filename}";
            bool existingFileFound = File.Exists(completePath);

            if (existingFileFound)
            {
                Console.WriteLine("Existing file with Employee data has been found");
            }
            else
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Directory is ready for saving files!");
                    Console.ResetColor();
                }
            }
        }
    }
}
