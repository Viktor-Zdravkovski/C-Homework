// Give the user an option to input numbers
// After inputing each number ask them if they want to input another with a Y/N question
// Store all numbers in a QUEUE
// When the user is done adding numbers print the number in the order that the user entered them from the QUEUE

Queue<double> queue = new Queue<double>();
Console.WriteLine("Write your number");
double usersInput = double.Parse(Console.ReadLine());
Console.WriteLine("Write your second number");
double secondUserInput = double.Parse(Console.ReadLine());
Console.WriteLine("Write your third number");
double thirdUserInput = double.Parse(Console.ReadLine());
queue.Enqueue(usersInput);
queue.Enqueue(secondUserInput);
queue.Enqueue(thirdUserInput);

while (true)
{

    Console.WriteLine("Do you want to input another number?: Y/N");
    char answerOfQuestion = char.Parse(Console.ReadLine());

    if (answerOfQuestion == 'y')
    {
        Console.WriteLine("Enter your number");
        double answer = double.Parse(Console.ReadLine());

        queue.Enqueue(answer);
        continue;
    }
    else if (answerOfQuestion == 'n')
    {
        Console.WriteLine("your numbers are: ");
        foreach (double num in queue)
        {
            Console.WriteLine(num);
        }
        break;
    }
    else
    {
        Console.WriteLine("Invalid number");
        break;
    }
}

