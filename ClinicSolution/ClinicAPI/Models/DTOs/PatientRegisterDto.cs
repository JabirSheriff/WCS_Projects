namespace ClinicAPI.Models.DTOs
{
    public class PatientRegisterDto 
    {
        public string Name { get; set; } = string.Empty;
        public float Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public decimal Phone { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
