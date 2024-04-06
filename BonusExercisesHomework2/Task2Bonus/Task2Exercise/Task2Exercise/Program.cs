using Task2Exercise.Domain.Domain.Models;
using Task2Exercise.Domain.Domain.Models.BaseModel;

Vehicle car = new Car();
Vehicle motorBike = new MotorBike();
Vehicle boat = new Boat();
Vehicle airplane = new Airplane();

Console.ForegroundColor = ConsoleColor.Green;
car.DisplayInfo();
motorBike.DisplayInfo();
boat.DisplayInfo();
airplane.DisplayInfo();
Console.ResetColor();

Console.WriteLine("\n");

Console.ForegroundColor = ConsoleColor.Cyan;
car.Drive();
motorBike.Wheelie();
boat.Sailing();
airplane.Fly();
Console.ResetColor();
Console.ReadLine();


// znam deka mozhe da se smenat mesto Vehicle da stoj za site posebno ( Car car ) i posle da se accessne samo metodata
// Car car = new car();
// car.Drive();
// no vo zadachata vika: From the previous task get the implementation and DO NOT CHANGE the implementation of the classes.