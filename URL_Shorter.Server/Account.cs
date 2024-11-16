using System.ComponentModel.DataAnnotations;

namespace URL_Shorter.Server
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
        public bool Admin {  get; set; }
    }
}
