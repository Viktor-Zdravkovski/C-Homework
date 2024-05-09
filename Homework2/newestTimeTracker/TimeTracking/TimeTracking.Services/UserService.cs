using System;
using System.Diagnostics;
using TimeTracking.Domain;
using TimeTracking.Domain.Activities.Enums;
using TimeTracking.Helpers;
using TimeTracking.Repository;
using TimeTracking.Repository.Interface;
using TimeTracking.Services.DTOs;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services
{
    public class UserService : IUserService
    {
        private IUserRepo _userRepo { get; }

        public UserService()
        {
            _userRepo = new UserRepo();
        }

        public User? Register(string firstName, string lastName, int age, string userName, string password)
        {
            User? exsitingUser = _userRepo.GetUserByUserName(userName);

            if (exsitingUser != null)
            {
                Console.WriteLine($"User with {userName} already exists");
                return null;
            }

            User? createdUser = User.Create(firstName, lastName, age, userName, password);

            if (createdUser != null)
            {
                _userRepo.Add(createdUser);
            }

            return createdUser;
        }

        public User? LogIn(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Please enter valid enter your username/password");
                return null;
            }

            User? user = _userRepo.GetUserByUserName(userName);

            if (user == null)
            {
                Console.WriteLine($"The user with {userName} does not exist");
                return null;
            }

            if (!user.HasCorrectPassword(password))
            {
                Console.WriteLine("Your password is incorrect");
                return null;
            }

            return user;
        }

        public void UpsertActivity(string userName, string activityName, string? subType, int? pages, int timeSpent)
        {
            User? user = _userRepo.GetUserByUserName(userName);

            if (user == null)
            {
                Console.WriteLine("Please enter a valid username");
                return;
            }

            user.UpsertActivity(activityName, subType, pages, timeSpent);
        }

        public StatsDto? GetUserStats(string choice, string userName)
        {
            User? user = _userRepo.GetUserByUserName(userName);

            int timePerActivity;
            string? favouriteTypePerActivity = null;
            int? totalNumberOfPages = null;

            if (user == null)
            {
                ConsoleColors.PrintError("Invalid user");
                return null;
            }

            switch (choice)
            {
                case "1":
                    timePerActivity = user.Activities.Where(x => x.ActivityName == "Reading").Sum(x => x.TimeSpentInMinutes) / 60;
                    totalNumberOfPages = user.Activities.Where(x => x.ActivityName == "Reading").Sum(x => x.ExtraInfo["Pages"]);
                    favouriteTypePerActivity = ((ReadingType?)user.Activities.Where(x => x.ActivityName == "Reading").OrderByDescending(x => x.TimeSpentInMinutes).FirstOrDefault()?.ExtraInfo["Type"])?.ToString();
                    break;
                case "2":
                    timePerActivity = user.Activities.Where(x => x.ActivityName == "Exerciseing").Sum(x => x.TimeSpentInMinutes) / 60;
                    favouriteTypePerActivity = ((ExerciseType?)user.Activities.Where(x => x.ActivityName == "Exerciseing").OrderByDescending(x => x.TimeSpentInMinutes).FirstOrDefault()?.ExtraInfo["Type"])?.ToString();
                    break;
                case "3":
                    timePerActivity = user.Activities.Where(x => x.ActivityName == "Working").Sum(x => x.TimeSpentInMinutes) / 60;
                    favouriteTypePerActivity = ((WorkingPlace?)user.Activities.Where(x => x.ActivityName == "Working").OrderByDescending(x => x.TimeSpentInMinutes).FirstOrDefault()?.ExtraInfo["Type"])?.ToString();
                    break;
                case "4":
                    timePerActivity = user.Activities.Where(x => x.ActivityName == "Other hobbies").Sum(x => x.TimeSpentInMinutes) / 60;
                    break;
                case "5":
                    timePerActivity = user.Activities.Sum(x => x.TimeSpentInMinutes) / 60;
                    break;
                default:
                    return null;
            }
            return new StatsDto
            {
                FavouriteType = favouriteTypePerActivity,
                Pages = totalNumberOfPages,
                TimeSpentInHours = timePerActivity
            };
        }

        public User? UpdateUserData(string userName, string password, string firstName, string lastName)
        {
            User? user = _userRepo.GetUserByUserName(userName);

            if (user == null)
            {
                ConsoleColors.PrintError("Invalid user");
                return null;
            }

            if (user.Password != password)
            {
                user.UpdatePassword(password);
            }

            if (user.FirstName != firstName)
            {
                user.UpdateFirstName(firstName);
            }

            if (user.LastName != lastName)
            {
                user.UpdateLastname(lastName);
            }

            return user;
        }
    }
}


