//● Declare a new array of integers with 5 elements
//● Initialize the array elements with values from input
//● Sum all the values and print the result in the console

Console.WriteLine("Exercise 05");
//Console.WriteLine("===== FIRST SOLUTIION =====");
//#region Exercise 05 (from presentation)
//int[] arrayOfNumbers = { 5, 23, 5, 2, 3 };
//int sum = arrayOfNumbers.Sum();
//for (int i = 0; i < arrayOfNumbers.Length; i++)
//{
//    Console.WriteLine(arrayOfNumbers[i]);
//}

//Console.WriteLine("the sum of numbers are: " + sum);
//#endregion

Console.WriteLine("===== SECOND SOLUTION =====");

#region secondSolution from the same exercise
Console.WriteLine("Type a random number please: ");
int numberOne = int.Parse(Console.ReadLine());
Console.WriteLine("Type a second random number please: ");
int numberTwo = int.Parse(Console.ReadLine());
Console.WriteLine("Type a third random number please: ");
int numberThree = int.Parse(Console.ReadLine());
Console.WriteLine("Type a fourth random number please: ");
int numberFour = int.Parse(Console.ReadLine());
Console.WriteLine("Type a fifth random number please: ");
int numberFive = int.Parse(Console.ReadLine());


int[] newArrayOfNumbers = new int[5];
newArrayOfNumbers[0] = numberOne;
newArrayOfNumbers[1] = numberTwo;
newArrayOfNumbers[2] = numberThree;
newArrayOfNumbers[3] = numberFour;
newArrayOfNumbers[4] = numberFive;
int sumOfGivenNumbers = 0;

for (int i = 0; i < newArrayOfNumbers.Length; i++)
{
    sumOfGivenNumbers += newArrayOfNumbers[i];
}

Console.WriteLine("The sum of your numbers is: " + sumOfGivenNumbers);


#endregion