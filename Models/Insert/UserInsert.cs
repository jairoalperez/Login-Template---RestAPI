using System.ComponentModel.DataAnnotations;

namespace LoginTemplate_RestAPI.Models
{
    public class UserInsert
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string CurrentZip { get; set; } = string.Empty;
        [Required]
        public string CurrentCity { get; set; } = string.Empty;
        [Required]
        public string CurrentState { get; set; } = string.Empty;
        [Required]
        public string CurrentCountry { get; set; } = string.Empty;
        [Required]
        public string PlaceOfBirth { get; set; } = string.Empty;
    }
}