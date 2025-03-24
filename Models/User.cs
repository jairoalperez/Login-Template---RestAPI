namespace LoginTemplate_RestAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set;} = string.Empty;
        public string FirstName { get; set;} = string.Empty;
        public string LastName { get; set;} = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set;} = string.Empty;
        public string CurrentZip { get; set; } = string.Empty;
        public string CurrentCity { get; set; } = string.Empty;
        public string CurrentState { get; set; } = string.Empty;
        public string CurrentCountry { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}