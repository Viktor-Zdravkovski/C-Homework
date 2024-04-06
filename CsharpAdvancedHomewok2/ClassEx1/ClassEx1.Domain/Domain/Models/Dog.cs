using ClassEx1.Domain.Domain.Models.BaseModel;

namespace ClassEx1.Domain.Domain.Models
{
    public class Dog : Pet
    {
        public bool GoodBoy { get; }
        public string FavouriteFood { get; }

        public Dog(string name, string type, int age, bool goodBoy, string favouriteFood) : base(name, type, age)
        {
            GoodBoy = goodBoy;
            FavouriteFood = favouriteFood;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"The pet with name: {Name},has {Age} years, Good boy {GoodBoy} and its favourite food is {FavouriteFood}");
        }
    }
}
