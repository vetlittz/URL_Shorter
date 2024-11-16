namespace URL_Shorter.Server.Models
{
    public class RegisterModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool Admin { get; set; }
    }
}
