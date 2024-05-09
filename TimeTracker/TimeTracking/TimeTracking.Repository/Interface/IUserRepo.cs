using TimeTracking.Domain;

namespace TimeTracking.Repository.Interface
{
    public interface IUserRepo
    {
        public User? GetUserByUserName(string userName);

        public void Add(User user);
    }
}
