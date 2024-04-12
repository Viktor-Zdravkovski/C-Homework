using LinqHomework2;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using static LinqHomework2.CarsData;

// Filter all cars that have origin from Europe.
List<Car> europeOrigin = (from car in CarsData.Cars
                          where car.Origin == "Europe"
                          select car).ToList();
// nekako sql syntax mi e polesna i zatoa gi reshavam na 2te nachina ( se nadevam deka tochno gi reshavam xD )

List<Car> europeOrigin1 = CarsData.Cars.Where(x => x.Origin == "Europe").ToList(); // tuka ne selektiram nishto tuku samo filtriram
List<string> europeOrigin2 = CarsData.Cars.Where(x => x.Origin == "Europe").Select(y => y.Model).ToList();


// Find all unique cylinder values for cars.
List<int> uniqueCylinder = CarsData.Cars.Select(x => x.Cylinders).Distinct().ToList();
List<string> uniqueCylinder1 = CarsData.Cars.DistinctBy(i => i.Cylinders).Select(o => $"{o.Cylinders}").ToList();
List<Car> uniqueCyl = CarsData.Cars.DistinctBy(x => x.Cylinders).OrderByDescending(y => y.Cylinders).ToList(); // " logika "

// Select all car names with their model names converted to uppercase.
List<string> uppercaseModels = CarsData.Cars.Select(x => x.Model.ToUpper()).ToList();

// Check if there are any cars with horsepower greater than 300.
bool ifHasGreaterThan = CarsData.Cars.Any(x => x.HorsePower > 300);

// Find the car with the highest horsepower.
Car fastestCar = CarsData.Cars.OrderBy(x => x.HorsePower).First();
Car fastestCar1 = CarsData.Cars.OrderByDescending(x => x.HorsePower).First(); // mislam deka istoto kje go dade ama ne sum siguren

// Filter all "Chevrolet" cars and order them by weight in descending order.
List<Car> chevroletFilter = CarsData.Cars.Where(x => x.Model == "Chevrolet").OrderByDescending(y => y.Weight).ToList();

// Find the car with the longest model name.
Car longestName = CarsData.Cars.OrderByDescending(s => s.Model.Length).First();

// Group cars by their origin and then order the groups by the number of cars in each group, in ascending order.
List<IGrouping<string, Car>> originGroup = CarsData.Cars.GroupBy(x => x.Origin).OrderBy(y => y.Count()).ToList(); // IGrouping go staviv poshto mi vadeshe eror
// Prochitav na google i vika deka pretstavuvalo kolekcija so slichni keys

// Find the first 5 cars with the highest horsepower. (hint: read about LINQ methods Skip() and Take())
List<Car> fastestCars = CarsData.Cars.OrderBy(x => x.HorsePower).Take(5).ToList();
List<Car> fastestCars1 = CarsData.Cars.OrderByDescending(x => x.HorsePower).Take(5).ToList(); // " logika "

// Find the car with the highest acceleration time.
IEnumerable<string> highestAcc = CarsData.Cars.OrderByDescending(y => y.AccelerationTime).Select(x => x.Model);

// Select only the model and horsepower of cars with horsepower greater than 200.
List<string> modelGreaterThan = CarsData.Cars.Where(x => x.HorsePower > 200).Select(y => $"{y.Model} {y.HorsePower}").ToList();

// Select all unique origins of cars, ordered alphabetically (ascending).
List<string> uniqueOrigins = CarsData.Cars.DistinctBy(x => x.Origin).OrderBy(y => y.Origin).Select(k => k.Origin).ToList();
List<Car> uniqueOrig = CarsData.Cars.OrderBy(x => x.Origin).DistinctBy(y => y.Origin).OrderByDescending(x => x.Origin).Reverse().ToList(); // " logika "
List<string> uniqOrig = CarsData.Cars.OrderBy(x => x.Origin).Select(y => y.Origin).ToList(); // " logika "

// Select all cars with more than 4 cylinders, and order them by origin and then by horsepower.
List<Car> moreThanCertainCyl = CarsData.Cars.Where(x => x.Cylinders > 4).OrderBy(y => y.Origin).ThenBy(k => k.HorsePower).ToList();

List<Car> moreThanCertainCyl1 = CarsData.Cars.Where(x => x.Cylinders > 4).OrderBy(y => y.Origin).ToList();
List<Car> moreThancyl = moreThanCertainCyl.OrderBy(x => x.HorsePower).ToList(); // mislam deka istoto kje go dade

// Filter all cars that have more than 6 Cylinders not including 6 after that Filter all cars that have exactly 4 Cylinders and have HorsePower more then 110.0. Join them in one result.
List<Car> moreThanCyl = CarsData.Cars.Where(x => x.Cylinders >= 7).ToList();
List<Car> certainCylExacly = CarsData.Cars.Where(x => x.Cylinders == 4 && x.HorsePower > 110).ToList();
List<Car> joined = moreThanCyl.Concat(certainCylExacly).ToList();

// EXPERIMENT
List<Car> moreThanCyl1 = CarsData.Cars.Where(x => x.Cylinders > 6).ToList();
List<Car> moreCyl = moreThanCyl1.Where(x => x.Cylinders == 4 && x.HorsePower > 110).ToList();
List<Car> someMoreCyl = moreThanCyl1.Concat(moreCyl).ToList();

// Filter all cars that have more then 200 HorsePower and Find out how much is the lowest, highest and average Miles per galon for these cars.
List<Car> moreThanHps = CarsData.Cars.Where(x => x.HorsePower > 200).ToList();
double lowestMpg = moreThanHps.Min(x => x.MilesPerGalon);
double highestMpg = moreThanHps.Max(x => x.MilesPerGalon);
double averageMpg = moreThanHps.Average(x => x.MilesPerGalon);

// EXPERIMENT
List<Car> moreThanHps1 = CarsData.Cars.Where(x => x.HorsePower > 200).ToList();
Car highestMpg1 = moreThanHps1.OrderByDescending(x => x.MilesPerGalon).First();
Car lowestMpg1 = moreThanHps1.OrderByDescending(x => x.MilesPerGalon).Reverse().First();
double averageMpg1 = moreThanHps1.Average(x => x.MilesPerGalon);



// Be creative and write requirement of your own choice :) (only one catch, must use at least 3 LINQ methods)
List<string> topLowestFuelUsage = CarsData.Cars.OrderByDescending(x => x.MilesPerGalon).Select(y => y.Model).Take(5).ToList();

// Be creative and write requirement of your own choice :) (only one catch, must use at least 3 LINQ methods)
List<Car> heaviestCarsEu = CarsData.Cars.OrderBy(x => x.Origin == "Europe").OrderByDescending(y => y.Weight).Take(5).ToList();

// Ova spored "Logika" go reshavav :D
List<Car> lightestCars = CarsData.Cars.OrderBy(x => x.Weight).OrderByDescending(y => y.Weight).Reverse().ToList();