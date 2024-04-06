using Task2Exercise.Domain.Domain.Models.BaseModel;

namespace Task2Exercise.Domain.Domain.Models
{
    public class Boat : Vehicle
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Im a boat and i do not have wheels :(");
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
            Console.WriteLine("The boat is sailing");
        }

        public override void Wheelie()
        {
            throw new NotImplementedException();
        }
    }
}
