using ClassEx1.Domain.Domain.Models.BaseModel;

namespace ClassEx1.Domain.Domain.Models
{
    public class Cat : Pet
    {
        public bool Lazy { get; }
        public int LivesLeft { get; }

        public Cat(string name, string type, int age, bool lazy, int livesLeft) : base(name, type, age)
        {
            Lazy = lazy;
            LivesLeft = livesLeft;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"The pet with name: {Name}, has {Age} years, Lazy {Lazy} and has {LivesLeft} lives");
        }
    }
}
