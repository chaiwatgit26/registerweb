using System.ComponentModel.DataAnnotations;

namespace RegisterWeb.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [Range(1, int.MaxValue)]
        public int OccupationId { get; set; }

        [Required]
        public string Sex { get; set; } = string.Empty;

        [Required]
        public string Profile { get; set; } = string.Empty;
    }
}