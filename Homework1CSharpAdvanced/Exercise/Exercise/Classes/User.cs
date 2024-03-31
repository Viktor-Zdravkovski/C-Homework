using Exercise.Interfaces;

namespace Exercise.Classes
{
    public abstract class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        public User(int id, string name, string username)
        {
            Id = id;
            Name = name;
            Username = username;
        }
        public virtual void PrintUser()
        {
            Console.WriteLine($"Users id: {Id}, Name: {Name}, {Username}");
        }
    }
}
