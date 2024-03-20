namespace Homework.Classes
{
    using Homework.Enums;
    public class Ceo : Employee
    {
        public Employee[] Employees { get; set; }
        public int Shares { get; set; }
        private double SharesPrice { get; set; }

        public Ceo(string fname, string lname, Employee[] employees, int shares) : base(fname, lname, Role.Ceo, 3000) //
        {
            Employees = employees;
            Shares = shares;
            SharesPrice = 0;
        }

        public void AddSharesPrice(double sharesPrice)
        {
            SharesPrice = sharesPrice;
        }

        public void PrintEmployees()
        {
            foreach (Employee employee in Employees)
            {
                employee.PrintInfo(); //
            }
        }

        public override double GetSalary()
        {
            return Salary + Shares * SharesPrice;
        }
    }

}
