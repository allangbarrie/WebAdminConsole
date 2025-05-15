using WebAdminConsole.Models;

namespace WebAdminConsole.ViewModels
{
    public class MountainResultsViewModel
    {
        public int? Position { get; set; }

        public string? TeamName { get; set; }

        public TimeSpan Stage4 { get; set; }

        public TimeSpan Stage5 { get; set; }

        public TimeSpan Stage16 { get; set; }

        public TimeSpan Stage18 { get; set; }

        public TimeSpan TotalTime { get; set; }

    }
}
