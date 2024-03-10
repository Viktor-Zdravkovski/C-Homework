namespace Homework04.Driver
{
    public class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public Driver? Driver { get; set; }

        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }

        public int CalculateSpeed()
        {
            if (Driver == null)
            {
                return Speed;
            }
            return Speed * Driver.Skill;

        }
        public static void RaceCars(Car firstCar, Car secondCar)
        {
            int firstCarSpeed = firstCar.CalculateSpeed();
            int secondCarSpeed = secondCar.CalculateSpeed();

            if (firstCarSpeed > secondCarSpeed)
            {
                Console.WriteLine($"The car {firstCar.Model} is the winner with driver {firstCar.Driver!.Name} and the speed was {firstCarSpeed} Km/h!!");
            }
            else if (firstCarSpeed < secondCarSpeed)
            {
                Console.WriteLine($"The car {secondCar.Model} is the winner with driver {secondCar.Driver!.Name} and the speed was {secondCarSpeed} Km/h!!");
            }
            else
            {
                Console.WriteLine($"Both cars were the same speed");
            }
        }
    }
}
