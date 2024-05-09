using TimeTracking.Domain;
using TimeTracking.Repository.DataBase;
using TimeTracking.Repository.Interface;

namespace TimeTracking.Repository
{
    public class UserRepo : IUserRepo
    {
        private UserDb _userDb { get; }

        public UserRepo()
        {
            _userDb = new UserDb();
        }

        public User? GetUserByUserName(string userName)
        {
            User? user = _userDb.Users.FirstOrDefault(x => x.UserName == userName);

            return user;
        }

        public void Add(User user)
        {
            _userDb.Users.Add(user);
        }
    }
}
