using System.Xml.Linq;

namespace Homework.Classes
{
    using Homework.Enums;
    public class Contractor : Employee
    {
        public double WorkHours { get; set; }
        public int PayPerHour { get; set; }
        public Manager Responsible { get; set; }

        public Contractor(string fname, string lname, double workHours, int payPerHour, Manager responsible) : base(fname, lname, Role.Other, 1500)
        {
            WorkHours = workHours;
            PayPerHour = payPerHour;
            Responsible = responsible; // 
        }

        public override double GetSalary()
        {
            return Salary = WorkHours * PayPerHour;
        }

        public string CurrentPosition()
        {
            return Responsible.Department; //
        }
    }
}