using TimeTracking.Domain;

namespace TimeTracking.Repository.DataBase
{
    public class UserDb
    {
        public List<User> Users = new List<User>()
        {
            new User("Viktor","Zdravkovski",22,"Viktor123","Viktor123"),
            new User("Mitko","Petrovski",42,"Mitko123","Mitko123"),
            new User("Dimitar","Vlahov",65,"Dimche123","Dimche123")
        };
    }
}
