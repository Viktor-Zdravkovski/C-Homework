using TimeTracking.Helpers;

namespace TimeTracking.Domain
{
    public class Activity
    {
        public string ActivityName { get; set; }

        public int TimeSpentInMinutes { get; set; }

        public Dictionary<string, int> ExtraInfo { get; set; }

        public Activity(string activityName, int timeSpentInMinutes, Dictionary<string, int> extraInfo)
        {
            ActivityName = activityName;
            TimeSpentInMinutes = timeSpentInMinutes;
            ExtraInfo = extraInfo;
        }

        public static Activity? Create(string activityName, int timeSpentInMinutes, int? subType, int? pages)
        {
            if (string.IsNullOrWhiteSpace(activityName))
            {
                ConsoleColors.PrintError("Please enter a valid activity");
                return null;
            }

            if ((activityName == "Reading" || activityName == "Exercise" || activityName == "Working") && !subType.HasValue)
            {
                ConsoleColors.PrintError("activity subtype invalid");
                return null;
            }

            if (activityName == "Reading" && !pages.HasValue)
            {
                ConsoleColors.PrintError("invalid number of pages");
                return null;
            }

            Dictionary<string, int> extraInfo = new Dictionary<string, int>();

            if (subType.HasValue)
            {
                extraInfo.Add("Type", subType.Value);
            }

            if (pages.HasValue)
            {
                extraInfo.Add("Pages", pages.Value);
            }

            return new Activity(activityName, timeSpentInMinutes, extraInfo);
        }

        public void UpdateTimeSpent(int timeSpent, int? pages)
        {
            TimeSpentInMinutes += timeSpent;

            if (ActivityName == "Reading" && pages.HasValue)
            {
                ExtraInfo["Pages"] += pages.Value;
            }
        }
    }
}
