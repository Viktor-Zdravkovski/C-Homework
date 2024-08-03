namespace BurgerShop.Domain
{
    public class Location : BaseEntity
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public int OpensAt { get; set; }

        public int ClosesAt { get; set; }

        //public Location(string name, string address, int opens, int closes)
        //{
        //    Name = name;
        //    Address = address;
        //    OpensAt = opens;
        //    ClosesAt = closes;
        //}
    }
}
