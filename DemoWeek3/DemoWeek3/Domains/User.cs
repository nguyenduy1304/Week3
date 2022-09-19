using System.ComponentModel.DataAnnotations;

namespace DemoWeek3.Domains
{
    public class User
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public UserDetail UserDetail { get; set; }
    }
}
