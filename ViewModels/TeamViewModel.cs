using System.ComponentModel.DataAnnotations;
using WebAdminConsole.Models;

namespace WebAdminConsole.ViewModels
{
    public class TeamViewModel
    {
        [Required]
        public int TeamId { get; set; }

        [Display(Name = "Team")]
        public string Name { get; set; }

        [Required]
        public int CaptainId { get; set; }
        public virtual Captain Captain { get; set; }

        [Required]
        public int TeamCategoryId { get; set; }
        public virtual TeamCategory TeamCategory { get; set; }

        [Required]
        public int? RunnerCount { get; set; }
    }
}
