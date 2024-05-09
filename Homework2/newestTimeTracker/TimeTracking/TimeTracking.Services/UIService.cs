using System.Diagnostics;
using TimeTracking.Domain;
using TimeTracking.Helpers;
using TimeTracking.Services.DTOs;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services
{
    public class UIService
    {
        private readonly IUserService _userService;
        protected User? CurrentUser { get; set; }

        public UIService()
        {
            _userService = new UserService();
        }

        public void Register()
        {
            Console.Clear();
            Console.WriteLine("Create your account today\n");
            Console.WriteLine("Enter Your First Name: ");
            string registerFirstName = Console.ReadLine();
            Console.WriteLine("Enter Your Last Name: ");
            string registerLastName = Console.ReadLine();
            Console.WriteLine("Enter Your Age");
            int.TryParse(Console.ReadLine(), out int regAge);
            Console.WriteLine("Enter Your UserName: ");
            string registerUserName = Console.ReadLine();
            Console.WriteLine("Enter Your Password: ");
            string registerPassword = Console.ReadLine();

            User? newRegisteredUser = _userService.Register(registerFirstName, registerLastName, regAge, registerUserName, registerPassword);

            if (newRegisteredUser != null)
            {
                ConsoleColors.PrintSuccess("You have successfuly created your account");
                CurrentUser = newRegisteredUser;
            }
        }

        public void LogIn()
        {
            Console.Clear();
            Console.WriteLine("Enter Your Credentials\n");
            Console.WriteLine("Enter Your UserName: ");
            string logInUserName = Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            string logInPassword = Console.ReadLine();

            User? user = _userService.LogIn(logInUserName, logInPassword);
            CurrentUser = user;
        }

        public void LogOut()
        {
            Console.Clear();
            if (CurrentUser == null)
            {
                Console.WriteLine("User has already logged out");
            }
            else
            {
                Console.WriteLine("Logging out...");
                CurrentUser = null;
            }
        }

        public void Exit()
        {
            Console.Clear();
            if (CurrentUser != null)
            {
                Console.WriteLine("You will be logged out");
                CurrentUser = null;
            }

            Console.WriteLine("Thank you for using TimeTracking Application");
        }

        public void Track()
        {
            Console.WriteLine("What would you like to track?\n");
            Console.WriteLine("1) Reading");
            Console.WriteLine("2) Exercising");
            Console.WriteLine("3) Working");
            Console.WriteLine("4) Other Hobbies");
            Console.WriteLine("5) Back");
            string trackChoice = Console.ReadLine();
            switch (trackChoice)
            {
                case "1":
                    StartTracking("Reading");
                    break;
                case "2":
                    StartTracking("Exercising");
                    break;
                case "3":
                    StartTracking("Working");
                    break;
                case "4":
                    StartTracking("Other hobbies");
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Please enter a valid choice");
                    break;
            }
        }

        private void StartTracking(string choice)
        {
            DateTime startTime = DateTime.Now;

            Console.WriteLine("The counter has started");
            Console.WriteLine("Press enter when to stop");

            ConsoleKeyInfo key = Console.ReadKey();

            while (key.Key != ConsoleKey.Enter)
            {
                key = Console.ReadKey();
            }

            DateTime endTime = DateTime.Now;
            TimeSpan totalTimeSpent = endTime - startTime;

            RequestExtraInfo(choice, Convert.ToInt32(totalTimeSpent.TotalMinutes));
        }

        private void RequestExtraInfo(string choice, int timeSpent)
        {
            int? pagesRead = null;
            string? subType = null;
            string activityName = choice;

            Console.WriteLine("Please enter extra info: ");

            switch (choice)
            {
                case "Reading":
                    Console.WriteLine("Enter pages you have read");
                    pagesRead = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter type: (BellesLettres/Fiction/ProfessionalLiterature");
                    subType = Console.ReadLine();
                    break;
                case "Exercising":
                    Console.WriteLine("Enter type: (General/Running/Sport) ");
                    subType = Console.ReadLine();
                    break;
                case "Working":
                    Console.WriteLine("Place where you working from: (Home/Office)");
                    subType = Console.ReadLine();
                    break;
                case "Other hobbies":
                    Console.WriteLine("Name of the hobby: ");
                    activityName = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice");
                    break;
            }

            _userService.UpsertActivity(CurrentUser!.UserName, activityName!, subType, pagesRead, timeSpent);
        }

        public void Stats()
        {
            Console.WriteLine("User Statistics\n");
            Console.WriteLine("Enter a number you want stats from: ");
            Console.WriteLine("1) Reading");
            Console.WriteLine("2) Exercising");
            Console.WriteLine("3) Working");
            Console.WriteLine("4) Hobbies");
            Console.WriteLine("5) Global");

            string statsChoice = Console.ReadLine();
            StatsDto? chosenChoice = _userService.GetUserStats(statsChoice, CurrentUser!.UserName);

            switch (statsChoice)
            {
                case "1":
                    Console.WriteLine($"You have spent {chosenChoice.TimeSpentInHours} hours");
                    Console.WriteLine($"You have read {chosenChoice.Pages} pages");
                    Console.WriteLine($"Your favourite type is {chosenChoice.FavouriteType}");
                    break;
                case "2":
                    Console.WriteLine($"You have spent {chosenChoice.TimeSpentInHours} hours");
                    Console.WriteLine($"Your favourite exercise is {chosenChoice.FavouriteType}");
                    break;
                case "3":
                    Console.WriteLine($"You have spent {chosenChoice.TimeSpentInHours} hours");
                    Console.WriteLine($"Your favourite type is {chosenChoice.FavouriteType}");
                    break;
                case "4":
                    Console.WriteLine($"You have spent {chosenChoice.TimeSpentInHours} hours");
                    break;
                case "5":
                    Console.WriteLine($"Total spent time {chosenChoice.TimeSpentInHours} hours");
                    Console.WriteLine($"Your favourite type is {chosenChoice.FavouriteType}");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        public void Menagment()
        {
            string changedPassword = CurrentUser.Password;
            string changedFirstName = CurrentUser.FirstName;
            string changedLastName = CurrentUser.LastName;
            string successMessage = string.Empty;

            Console.WriteLine("What would you like to do");
            Console.WriteLine("1) Change Password");
            Console.WriteLine("2) Change First Name");
            Console.WriteLine("3) Change Last Name");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter your new password");
                    changedPassword = Console.ReadLine();
                    successMessage = "Your password has been successfuly changed";
                    break;
                case "2":
                    Console.WriteLine("Enter your new First name");
                    changedFirstName = Console.ReadLine();
                    successMessage = "Your firstname has been successfuly changed";
                    break;
                case "3":
                    Console.WriteLine("Enter your new last name");
                    changedLastName = Console.ReadLine();
                    successMessage = "Your lastname has been successfuly changed";
                    break;
                default:
                    ConsoleColors.PrintError("Invalid choice");
                    return;
            }

            User? updatedUser = _userService.UpdateUserData(CurrentUser.UserName, changedPassword!, changedFirstName!, changedLastName!);

            if (updatedUser != null)
            {
                Console.WriteLine(successMessage);
            }
        }
    }
}
