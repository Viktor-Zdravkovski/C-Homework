using TimeTracking.Domain;
using TimeTracking.Services;

namespace TimeTracking.App
{
    public class TimeTrackingUI : UIService
    {
        public TimeTrackingUI()
        {

        }

        public void InitApp()
        {
            while (true)
            {
                if (CurrentUser == null)
                {
                    Console.WriteLine("Choose one of the options");
                    Console.WriteLine("1) Register");
                    Console.WriteLine("2) LogIn");
                    Console.WriteLine("3) Exit");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Register();
                            break;
                        case "2":
                            LogIn();
                            break;
                        case "3":
                            Exit();
                            return;
                        default:
                            Console.WriteLine("Invalid choice");
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("What would you like to do today? - " + CurrentUser.FirstName);
                    Console.WriteLine("1) Track");
                    Console.WriteLine("2) UserStats");
                    Console.WriteLine("3) Account Menagment");
                    Console.WriteLine("4) LogOut");

                    string logInChoice = Console.ReadLine();
                    switch (logInChoice)
                    {
                        case "1":
                            Track();
                            break;
                        case "2":
                            Stats();
                            break;
                        case "3":
                            Menagment();
                            break;
                        case "4":
                            LogOut();
                            break;
                        default:
                            Console.WriteLine("Enter a valid number");
                            continue;
                    }
                }
            }
        }
    }
}
