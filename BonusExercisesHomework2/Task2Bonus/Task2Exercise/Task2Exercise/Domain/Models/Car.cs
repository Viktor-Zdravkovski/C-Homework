using Task2Exercise.Domain.Domain.Models.BaseModel;

namespace Task2Exercise.Domain.Domain.Models
{
    public class Car : Vehicle
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Im a car and i drive on 4 wheels :)");
        }

        public override void Drive()
        {
            Console.WriteLine("The car is driving");
        }

        public override void Fly()
        {
            throw new NotImplementedException();
        }

        public override void Sailing()
        {
            throw new NotImplementedException();
        }

        public override void Wheelie()
        {
            throw new NotImplementedException();
        }
    }
}
