//Make a console application called SumOfEven. Inside it create an array of 6 integers. Get numbers from the input, find and print the sum of the even numbers from the array:

//Test Data:
//Enter integer no.1:
//4
//Enter integer no.1:
//3
//Enter integer no.1:
//7
//Enter integer no.1:
//3
//Enter integer no.1:
//2
//Enter integer no.1:
//8
//Expected Output:
//The result is: 14

Console.WriteLine("Sum Or Even???");

Console.WriteLine("Enter integer no.1: ");
int firstNumber = int.Parse(Console.ReadLine());
Console.WriteLine("Enter integer no.2: ");
int secondNumber = int.Parse(Console.ReadLine());
Console.WriteLine("Enter integer no.3: ");
int thirdNumber = int.Parse(Console.ReadLine());
Console.WriteLine("Enter integer no.4: ");
int fourthNumber = int.Parse(Console.ReadLine());
Console.WriteLine("Enter integer no.5: ");
int fifthNumber = int.Parse(Console.ReadLine());
Console.WriteLine("Enter integer no.6: ");
int sixthNumber = int.Parse(Console.ReadLine());

int[] numbers = new int[6];
numbers[0] = firstNumber;
numbers[1] = secondNumber;
numbers[2] = thirdNumber;
numbers[3] = fourthNumber;
numbers[4] = fifthNumber;
numbers[5] = sixthNumber;

int sum = 0;

for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i] % 2 == 0)
    {
        Console.WriteLine(numbers[i] + ": the number IS even ");
        sum += numbers[i];
    }
    else
    {
        Console.WriteLine(numbers[i] + ": the number is NOT even");
    }
}
Console.WriteLine("the sum of your given numbers is: " + sum);