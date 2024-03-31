using Exercise.Interfaces;
using System.Xml.Linq;

namespace Exercise.Classes
{
    public class Student : User, IStudent
    {
        public List<int> Grades = new List<int>();


        public Student(int id, string name, string username, List<int> grades) : base(id, name, username)
        {
            Grades = grades;
        }

        public override void PrintUser()
        {
            base.PrintUser();
            Console.WriteLine($"Student's Average grades is: {Grades.Average()}");
        }

        public void PrintGrades()
        {
            throw new NotImplementedException();
        }

    }
}
