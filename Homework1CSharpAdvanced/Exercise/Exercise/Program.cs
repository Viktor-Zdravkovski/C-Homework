using Exercise.Classes;

Console.WriteLine("Exercise 1");

Teacher teacher1 = new Teacher(12, "Damjan", "Damjan123", new List<string>
{
    "Mathematic",
    "Physics",
    "Chemistry",
    "Biology"
});
teacher1.PrintUser();



Teacher teacher2 = new Teacher(152, "Dime", "Dime523", new List<string>
{
    "Sport",
    "Aikido",
    "Karate",
    "MMA",
    "Krav-Maga"
});
teacher2.PrintUser();

Student student1 = new Student(325, "Viktor", "Zdravkovski", new List<int>
{
    5,3,6,2,5
});
student1.PrintUser();

Student student2 = new Student(322, "Mile", "Milanovski", new List<int>
{
    2,3,5,1,2,
});
student2.PrintUser();