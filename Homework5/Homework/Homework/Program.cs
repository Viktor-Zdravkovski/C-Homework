using Homework.Classes;

Console.WriteLine("Homework 5");

Manager manager1 = new Manager("Boban", "Geshov", "ESZ");
Manager manager2 = new Manager("Gele", "Trajkovski", "EBR");

Employee[] company = new Employee[5]
{
    new Contractor("Ron","Ronsky", 6,200, manager1),
    new Contractor("Bob","Marley",2,400, manager2),
    manager1,
    manager2,
    new SalesPerson("Zoki", "Petkov")
};

Ceo ceo = new Ceo("Viktor", "Zdravkovski", company, 6000);
ceo.PrintInfo();
ceo.PrintEmployees();
ceo.GetSalary();