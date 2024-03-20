namespace Homework.Classes
{
    using Homework.Enums;
    public class SalesPerson : Employee
    {
        private double SuccessSaleRevenue { get; set; }

        public SalesPerson(string fname, string lname) : base(fname, lname, Role.Salesman, 700)
        {
            FirstName = fname;
            LastName = lname;
            SuccessSaleRevenue = 0; //
        }

        public override double GetSalary() //
        {
            if (SuccessSaleRevenue <= 2000)
            {
                Salary += 500;
            }
            else if (SuccessSaleRevenue >= 5000)
            {
                Salary += 1000;
            }
            else
            {
                Salary += 1500;
            }
            return Salary;
        }

        public void AddSuccessRevenue(int number) //
        {
            SuccessSaleRevenue = number;
        }
    }
}
