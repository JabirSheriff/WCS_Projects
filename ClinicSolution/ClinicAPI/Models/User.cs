namespace ClinicAPI.Models
{
    public class User
    {
        public string Email { get; set; }=string.Empty;
        public byte[] Password { get; set; } 
        public byte[] HasKey { get; set; } 
        public string Role { get; set; } = "Patient";
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
    }
}
