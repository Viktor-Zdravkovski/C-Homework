
// EXERCISE 06 FROM THE PRESENTATION

//● Create an array with names
//● Give an option to the user to enter a name from the keyboard
//● After entering the name put it in the array
//● Ask the user if they want to enter another name(Y / N)
//● Do the same process over and over until the user enters N
//● Print all the names after user enters N


#region Exercise 06 (From Presentation)
string[] arrayOfNames = { "Zoki", "Trpe", "Trajana", "Trpana" };

Console.WriteLine("Enter a name: ");
string newName = Console.ReadLine();

//if (newName == null || newName == "number")
//{
//    Console.WriteLine("You didin't enter an expected name :/"); // sakav da napravam validacija no go ignorira cel if condition i prodolzhuva so izvrshuvanje na kodot...
//    return;
//}


string[] newArrayOfNames = new string[arrayOfNames.Length + 1];
newArrayOfNames[0] = newName;

for (int i = 0; i < arrayOfNames.Length; i++)
{
    newArrayOfNames[i + 1] = arrayOfNames[i];
}

arrayOfNames = newArrayOfNames;

while (true)
{
    Console.WriteLine("Do you want to enter another name? (Y/N) ");
    string input = Console.ReadLine();
    if (input == "Y" || input == "y")
    {
        Console.WriteLine("Enter the next name: ");
        string nextName = Console.ReadLine();

        newArrayOfNames = new string[arrayOfNames.Length + 1];
        newArrayOfNames[0] = nextName;

        for (int i = 0; i < arrayOfNames.Length; i++)
        {
            newArrayOfNames[i + 1] = arrayOfNames[i];
        }

        arrayOfNames = newArrayOfNames;
    }
    else
    {
        foreach (string name in arrayOfNames)
        {
            Console.WriteLine(name);
            //Array.Reverse(arrayOfNames); // gi dava random vo nizata
        }
        break;
    }
}

// iskreno za ova malce mi trebashe pomosh bidejki edino neshto shto ne znaev i shto koristev chatGPT
// beshe toa shto ne znaev kako da go zachuvam novoto dadeno ime vo vekje postoechkata niza
// se nadevam deka ne e problem, drugoto gore-dolu so dovolno napishan kod bi mozhel da se snajdam
#endregion



//#region SecondSolution Ex:6
//string firstName = "Viktor";
//string secondName = "Milorad";
//string thirdName = "Dragoslav";

//string[] anArrayOfNames = new string[3];
//anArrayOfNames[0] = firstName;
//anArrayOfNames[1] = secondName;
//anArrayOfNames[2] = thirdName;

//Console.WriteLine("Enter a name you would like to put to an existing array: ");
//string newAddedName = Console.ReadLine();
//Array.Resize(ref anArrayOfNames, 4);

//anArrayOfNames[3] = newAddedName;

//for (int i = 0; i < anArrayOfNames.Length; i++)
//{
//    Console.WriteLine("Would you like to put another name in the same array?: (Y/N)");
//    string character = Console.ReadLine();
//    if (character == "Y" || character == "y")
//    {
//        Console.WriteLine("Write the name: ");
//        string anotherNameToAdd = Console.ReadLine();
//        Array.Resize(ref anArrayOfNames, 4 + i);
//        anArrayOfNames[3 + i] = anotherNameToAdd;
//    }
//    else
//    {
//        foreach (string name in anArrayOfNames)
//        {
//            Console.WriteLine(name);
//        }
//        break;
//    }
//}

//#endregion


