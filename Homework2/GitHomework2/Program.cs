Console.WriteLine("Student-roup");
//#region FirstSolution
//string[] studentsG1 = new string[5];
//studentsG1[0] = "Zdravko";
//studentsG1[1] = "Petko";
//studentsG1[2] = "Stanko";
//studentsG1[3] = "Branko";
//studentsG1[4] = "Trajko";

//string[] studentsG2 = new string[5];
//studentsG2[0] = "Milorad";
//studentsG2[1] = "Dragoslav";
//studentsG2[2] = "Bogdan";
//studentsG2[3] = "Viktor";
//studentsG2[4] = "Zlate";

//Console.WriteLine("Type number 1 to get students from G1/Type number 2 to get students from G2");
//int chosenNumber = int.Parse(Console.ReadLine());

//for (int i = 0; i < studentsG1.Length; i++)
//{
//    if (chosenNumber == 1)
//    {
//        Console.WriteLine(studentsG1[i]);
//    }
//    else if (chosenNumber == 2)
//    {
//        Console.WriteLine(studentsG2[i]);
//    }
//}


//// iskreno ja reshiv spored logika i ne mi e jasno zashto raboti for-ot
//#endregion

#region SecondSolution
string[] studentsInG1 = new string[5];
studentsInG1[0] = "Zdravko";
studentsInG1[1] = "Petko";
studentsInG1[2] = "Stanko";
studentsInG1[3] = "Branko";
studentsInG1[4] = "Trajko";

string[] studentsInG2 = new string[5];
studentsInG2[0] = "Milorad";
studentsInG2[1] = "Dragoslav";
studentsInG2[2] = "Bogdan";
studentsInG2[3] = "Viktor";
studentsInG2[4] = "Zlate";

Console.WriteLine("Type number 1 to get students from G1/Type number 2 to get students from G2");
int chosenclass = int.Parse(Console.ReadLine());

if (chosenclass == 1)
{
    for (int i = 0; i < studentsInG1.Length; i++)
    {
        Console.WriteLine("The students in G1 are: " + studentsInG1[i]);
    }
}
else if (chosenclass == 2)
{
    for (int i = 0; i < studentsInG2.Length; i++)
    {
        Console.WriteLine("The students in G2 are: " + studentsInG2[i]);
    }
}
else
{
    Console.WriteLine("Invalid Class");
}

#endregion