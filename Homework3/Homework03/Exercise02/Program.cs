//Write a method that formats a given date and time as a string in a specific format.
// Get the needed inputs from screen.

//Allowed formats: "MM/dd/yyyy", "MM/dd/yyyy hh:mm:ss", "dddd, dd MMMM yyyy HH:mm:ss", "MM.dd.yyyy"
//Bonus: Create separate method that validates whether the entered format is allowed

//static void everyFormat()
//{
//    Console.WriteLine("Please enter a date and time in the following format MM/dd/yyyy hh:mm:ss:");
//    string Yearinput = Console.ReadLine();

//    DateTime dateTime;
//    if (DateTime.TryParse(Yearinput, out dateTime))
//    {
//        Console.WriteLine("Formatted date is: ");
//        Console.WriteLine(dateTime.ToString("MM/dd/yyyy"));
//        Console.WriteLine(dateTime.ToString("MM/dd/yyyy hh:mm:ss"));
//        Console.WriteLine(dateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
//        Console.WriteLine(dateTime.ToString("MM.dd.yyyy"));
//    }
//    else
//    {
//        Console.WriteLine("Invalid date and time format. Please try again.");
//    }
//}

//everyFormat();

// 



static void stockFormat()
{
    DateTime customdate = new DateTime(2000, 8, 20, 5, 20, 35);
    Console.Write("what format would you like to be printed \n \"MM/dd/yyyy\" \n MM/dd/yyyy hh:mm:ss \n dddd, dd MMMM yyyy HH:mm:ss \n MM.dd.yyyy \n \n");
    string formatedString = Console.ReadLine();

    if (formatedString == "MM/dd/yyyy".ToLower())
    {
        Console.WriteLine(customdate.ToString("MM / dd / yyyy"));

    }
    else if (formatedString == "MM/dd/yyyy hh:mm:ss".ToLower())
    {
        Console.WriteLine(customdate.ToString("MM/dd/yyyy hh:mm:ss".ToLower()));
    }
    else if (formatedString == "dddd, dd MMMM yyyy HH:mm:ss".ToLower())
    {
        Console.WriteLine(customdate.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
    }
    else if (formatedString == "MM.dd.yyyy".ToLower())
    {
        Console.WriteLine(customdate.ToString("MM.dd.yyyy"));
    }
    else
    {
        Console.WriteLine("Entered format is allowed not allowed ");
    }
}

stockFormat();