namespace ClinicAPI.Models.DTOs
{
    public class DoctorRegisterDto
    {
        public string Name { get; set; } = string.Empty;
        public float Experience { get; set; }
        public string Email { get; set; } = string.Empty;
        public decimal Phone { get; set; }
        public string Password { get; set; } = string.Empty;
        public List<int> SpecialityIds { get; set; } = new List<int>(); // Specializations
    }
}