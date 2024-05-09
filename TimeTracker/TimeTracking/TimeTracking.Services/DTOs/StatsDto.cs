namespace TimeTracking.Services.DTOs
{
    public class StatsDto
    {
        public int TimeSpentInHours { get; set; }

        public int? Pages { get; set; }

        public string? FavouriteType { get; set; }
    }
}
