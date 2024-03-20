
namespace Homework.Classes
{
    using Homework.Enums;
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        protected double Salary { get; set; }

        public Employee(string fname, string lname, Role role, double salary)
        {
            FirstName = fname;
            LastName = lname;
            Role = role;
            Salary = salary;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"FirstName: {FirstName} LastName: {LastName} and his salary is {Salary}");
        }

        public virtual double GetSalary()
        {
            return Salary;
        }
    }
}
