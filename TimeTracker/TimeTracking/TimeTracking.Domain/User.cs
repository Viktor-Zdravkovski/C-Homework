

using TimeTracking.Domain.Activities.Enums;
using TimeTracking.Helpers;

namespace TimeTracking.Domain
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; }

        public string UserName { get; }

        public string Password { get; set; }

        public List<Activity> Activities { get; }

        public User(string firstName, string lastName, int age, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            UserName = userName;
            Password = password;
            Activities = new List<Activity>();
        }

        public static User? Create(string firstName, string lastName, int age, string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                ConsoleColors.PrintError("Please enter valid information");
                return null;
            }

            if (age < 18 || age > 120)
            {
                ConsoleColors.PrintError("Sorry you are older/younger than recomended age");
                return null;
            }

            if (userName.Length < 5 || password.Length < 6)
            {
                ConsoleColors.PrintError("Either your username is less than 5 characters or password is less than 6 characters");
                return null;
            }

            if (firstName.Length < 2 || lastName.Length < 2)
            {
                ConsoleColors.PrintError("Your firstname or lastname is less than 2 characters");
                return null;
            }

            User user = new(firstName, lastName, age, userName, password);
            return user;
        }

        public bool HasCorrectPassword(string password)
        {
            return Password == password;
        }

        public void UpsertActivity(string activityName, string? subType, int? pages, int timeSpent)
        {
            int? subTypeEnum = null;

            if (subType != null)
            {
                switch (activityName)
                {
                    case "Reading":
                        subTypeEnum = (int)Enum.Parse(typeof(ReadingType), subType);
                        break;
                    case "Exercise":
                        subTypeEnum = (int)Enum.Parse(typeof(ExerciseType), subType);
                        break;
                    case "Working":
                        subTypeEnum = (int)Enum.Parse(typeof(WorkingPlace), subType);
                        break;
                    default:
                        break;
                }
            }

            Activity? activity = Activities.FirstOrDefault(x => x.ActivityName == activityName && ((x.ExtraInfo.ContainsKey("Type") && x.ExtraInfo["Type"] == subTypeEnum) || !x.ExtraInfo.ContainsKey("Type")));

            if (activity != null)
            {
                activity.UpdateTimeSpent(timeSpent, pages);
                return;
            }

            Activity? createdActivity = Activity.Create(activityName, timeSpent, subTypeEnum, pages);

            if (createdActivity == null)
            {
                return;
            }

            Activities.Add(createdActivity);
        }

        public void UpdatePassword(string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                ConsoleColors.PrintError("Please enter password");
                return;
            }
            else if (newPassword.Length < 6)
            {
                ConsoleColors.PrintError("Your password is less than 6 characters");
                return;
            }

            Password = newPassword;
        }

        public void UpdateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                ConsoleColors.PrintError("Please enter valid firstname");
                return;
            }
            else if (firstName.Length < 2)
            {
                ConsoleColors.PrintError("Your firstname is less than 2 characters");
                return;
            }

            FirstName = firstName;
        }

        public void UpdateLastname(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                ConsoleColors.PrintError("Please enter valid lastname");
                return;
            }
            else if (lastName.Length < 2)
            {
                ConsoleColors.PrintError("Your lastname is less than 2 characters");
                return;
            }

            LastName = lastName;
        }
    }
}
