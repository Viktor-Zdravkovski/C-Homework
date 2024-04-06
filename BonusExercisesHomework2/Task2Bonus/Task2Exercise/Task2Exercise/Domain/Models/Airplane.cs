using Task2Exercise.Domain.Domain.Models.BaseModel;

namespace Task2Exercise.Domain.Domain.Models
{
    public class Airplane : Vehicle
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Im a plane i have couple of wheels :)");
        }

        public override void Drive()
        {
            throw new NotImplementedException();
        }

        public override void Fly()
        {
            Console.WriteLine("The airplane is flying");
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
