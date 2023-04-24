using System.ComponentModel.DataAnnotations;

namespace WebAdminConsole.Models
{
    public class Team
    {
        [Required]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(40, ErrorMessage = "Name cannot be longer than 40 characters.")]
        public string Name { get; set; }
        public int CaptainId { get; set; }
        public int TeamCategoryId { get; set; }

        public TeamCategory TeamCategory { get; set; }
        public Captain Captain { get; set; }
    }
}
