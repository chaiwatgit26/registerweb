using System.ComponentModel.DataAnnotations;

namespace RegisterWeb.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int OccupationId { get; set; }
    }
}