// BONUS 1

// Given a string, create a method to reverse the case. All lower-cased letters should be upper-cased, and vice versa.
//ReverseCase("Happy Birthday") ➞ "hAPPY bIRTHDAY"

//ReverseCase("MANY THANKS") ➞ "many thanks"

//ReverseCase("sPoNtAnEoUs") ➞ "SpOnTaNeOuS"

Console.WriteLine("==== BONUS 1 ====");

static string UpperLower(string sdfgsdg)
{

    Console.Write("Write a word that you want to be reversed: ");
    //string inputWordValue = Console.ReadLine();
    string inputWordValue = sdfgsdg;
    char[] inputCharsValue = inputWordValue.ToCharArray();
    char[] newCharArray = new char[inputCharsValue.Length];

    for (int i = 0; i < inputCharsValue.Length; i++)
    {
        if (Char.IsLower(inputCharsValue[i]))
        {
            newCharArray[i] = char.ToUpper(inputCharsValue[i]);
        }
        else if (Char.IsUpper(inputCharsValue[i]))
        {
            newCharArray[i] = char.ToLower(inputCharsValue[i]);
        }
        else
        {
            newCharArray[i] = inputCharsValue[i];
        }
    }
    string reversedString = new string(newCharArray);
    return reversedString;

}
string reversedWord = UpperLower("Happy BirthDay");
string reverseWord1 = UpperLower("MANY THANKS");
string reverseWord2 = UpperLower("sPoNtAnEoUs");

Console.WriteLine(reversedWord);
Console.WriteLine(reverseWord1);
Console.WriteLine(reverseWord2);


