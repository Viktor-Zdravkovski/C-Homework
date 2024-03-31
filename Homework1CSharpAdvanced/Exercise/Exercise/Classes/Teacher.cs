using Exercise.Interfaces;

namespace Exercise.Classes
{
    public class Teacher : User, ITeacher
    {
        public List<string> Subjects { get; }
        public Teacher(int id, string name, string username, List<string> subject) : base(id, name, username)
        {
            Subjects = subject;
        }

        public override void PrintUser()
        {
            Console.WriteLine($"The total number of subjects is: {Subjects.Count}");
        }

        public void PrintSubjects()
        {
            Console.WriteLine($"The subjects are: {Subjects}"); ;
        }
    }
}
