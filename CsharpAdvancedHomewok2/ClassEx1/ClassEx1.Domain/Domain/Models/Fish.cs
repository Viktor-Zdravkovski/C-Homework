using ClassEx1.Domain.Domain.Models.BaseModel;

namespace ClassEx1.Domain.Domain.Models
{
    public class Fish : Pet
    {
        public string Color { get; }
        public string Size { get; }

        public Fish(string name, string type, int age, string color, string size) : base(name, type, age)
        {
            Color = color;
            Size = size;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"The pet with name: {Name}, has {Age} years, is {Color} color and its {Size} size");
        }
    }
}
