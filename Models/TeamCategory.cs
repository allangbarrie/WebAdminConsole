using System.ComponentModel.DataAnnotations;

namespace WebAdminConsole.Models
{
    public class TeamCategory
    {
        [Required]
        public int TeamCategoryId { get; set; }

        public string Name { get; set; }
    }
}
