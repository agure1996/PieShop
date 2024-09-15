using PieShopHRM.HR;

namespace PieShop.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Perform_Adds_NumberOfHours()
        {

            //arrange
            Employee employee = new Employee("James", "Gordon", "JG@gmail.com", new DateTime(11 / 21 / 1932), 11);

            //act

            int numberOfHrs = 3;
            //assign

            employee.performWork(numberOfHrs);

            Assert.Equal(3, employee.numberOfHoursWorked);
        }


        [Fact]
        public void Perform_Adds_DefaultNumberOfHours_IfNoValueSpecified()
        {

            //arrange
            Employee employee = new Employee("James", "Gordon", "JG@gmail.com", new DateTime(11 / 21 / 1932), 11);

            //act

           
            //assign

            employee.performWork();

            Assert.Equal(1, employee.numberOfHoursWorked);
        }
    }
}