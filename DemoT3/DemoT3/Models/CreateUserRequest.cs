using System.ComponentModel.DataAnnotations;

namespace DemoT3.Models
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(200)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(200)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
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

    }
}
