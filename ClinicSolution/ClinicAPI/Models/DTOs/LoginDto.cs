using System.ComponentModel.DataAnnotations;




namespace ClinicAPI.Models.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters long")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password cannot be empty")]
        [MinLength(3, ErrorMessage = "Password must be at least 3 characters long")]
        public string Password { get; set; } = string.Empty;
    }
}