using System.Collections.Generic;
using TimeTracking.Domain;
using TimeTracking.Services.DTOs;

namespace TimeTracking.Services.Interfaces
{
    public interface IUserService
    {
        User? LogIn(string userName, string password);

        User? Register(string firstName, string lastName, int age, string userName, string password);

        void UpsertActivity(string userName, string activityName, string? subType, int? pages, int timeSpent);

        StatsDto? GetUserStats(string choice, string userName);

        User? UpdateUserData(string userName, string password, string firstName, string lastName);
    }
}
