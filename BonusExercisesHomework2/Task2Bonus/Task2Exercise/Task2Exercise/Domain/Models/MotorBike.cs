using Task2Exercise.Domain.Domain.Models.BaseModel;

namespace Task2Exercise.Domain.Domain.Models
{
    public class MotorBike : Vehicle
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Im a motorbike and i drive on 2 wheels :)");
        }

        public override void Drive()
        {
            throw new NotImplementedException();
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
            Console.WriteLine("The motorbike is driving on one wheel");
        }

    }
}
