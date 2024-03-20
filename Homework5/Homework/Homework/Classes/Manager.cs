namespace Homework.Classes
{
    using Homework.Enums;
    public class Manager : Employee
    {
        private double Bonus { get; set; }
        public string Department { get; set; }

        public Manager(string fname, string lname, string department) : base(fname, lname, Role.Manager, 1000)
        {
            FirstName = fname;
            LastName = lname;
            Department = department;
            Bonus = 0;
        }

        public void AddBonus(double bonus)
        {
            Bonus += bonus;
        }

        public override double GetSalary()
        {
            return Salary + Bonus;
        }

    }
}
