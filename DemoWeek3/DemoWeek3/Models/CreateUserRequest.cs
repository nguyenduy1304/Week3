using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWeek3.Models
{
    public class CreateUserRequest
    {
        [Required]
        [StringLength(200)]
        public string Username { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public String FirstName { get; set; }

        [StringLength(50)]
        public String LastName { get; set; }

        [StringLength(15)]
        public String PhoneNumber { get; set; }

        [StringLength(255)]
        public String Address { get; set; }

        [StringLength(50)]
        public String IdUser { get; set; }
    }
}
