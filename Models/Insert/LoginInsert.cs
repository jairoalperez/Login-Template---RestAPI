using System.ComponentModel.DataAnnotations;

namespace LoginTemplate_RestAPI.Models
{
    public class LoginInsert
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}