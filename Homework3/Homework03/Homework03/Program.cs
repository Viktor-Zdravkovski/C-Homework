// Make a method called AgeCalculator
// The method will have one input parameter, your birthday date
// The method should return your age
// Show the age of a user after he inputs a date

#region BasicYearCalc
//static void main()
//{
//    Console.WriteLine("Vnesi godina vo koja si roden: ");
//    int birthyear = int.Parse(Console.ReadLine());
//    DateTime dateTime = DateTime.Now;
//    int novagod = dateTime.Year - birthyear;
//    Console.WriteLine("Imate " + novagod + " Godini");
//}

//main();
#endregion

#region ageCalc Without method
//Console.WriteLine("Todays date is " + DateTime.Now.ToLongDateString());
//Console.WriteLine("Enter your birthdate (MM/dd/yyyy):");
//DateTime inputBirthdate = DateTime.Parse(Console.ReadLine());

//DateTime currentDate = DateTime.Now;
//int age = currentDate.Year - inputBirthdate.Year;

//if (currentDate.Month < inputBirthdate.Month || (currentDate.Month == inputBirthdate.Month && currentDate.Day < inputBirthdate.Day))
//{
//    age--;
//    Console.WriteLine(age);
//}
//else
//{
//    Console.WriteLine("Your age is: " + age);
//}
#endregion

#region AgeCalc with VOID method

//static void Agecalc()
//{
//    Console.WriteLine("When were you born?: (mm/dd/yyyy)");
//    DateTime inputBirthdate = DateTime.Parse(Console.ReadLine());

//    DateTime currentDate = DateTime.Now;
//    int ageCalculator = currentDate.Year - inputBirthdate.Year;

//    if (currentDate.Month < inputBirthdate.Month || (currentDate.Month == inputBirthdate.Month && currentDate.Day < inputBirthdate.Day))
//    {
//        ageCalculator--;
//        Console.WriteLine(ageCalculator);
//    }
//    else
//    {
//        Console.WriteLine(ageCalculator);
//    }
//}

//Agecalc();

#endregion

#region AgeCalc with input Parameter
Console.WriteLine("Todays date is " + DateTime.Now.ToLongDateString());
static int AgeCalculator(DateTime birthdate)
{
    DateTime currentDate = DateTime.Now;
    int age = currentDate.Year - birthdate.Year;

    if (currentDate.Month < birthdate.Month || (currentDate.Month == birthdate.Month && currentDate.Day < birthdate.Day))
    {
        age--;
        return age;
    }

    return age;
}
static void Main()
{
    Console.WriteLine("Please enter your birthdate in the format MM/dd/yyyy:");
    string birthdateInput = Console.ReadLine();

    DateTime inputBirthdate;
    if (DateTime.TryParse(birthdateInput, out inputBirthdate))
    {
        int age = AgeCalculator(inputBirthdate);
        Console.WriteLine("Your age is: " + age);
    }
    else
    {
        Console.WriteLine("Invalid birthdate format. Please try again.");
    }
}
Main();

#endregion