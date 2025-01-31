namespace ClinicAPI.Models
{
    public class Doctor
    {
        public string DoctorNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public float Experience { get; set; }
        public decimal Phone { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public ICollection<Appointment>? Appointments { get; set; }
        public User? User { get; set; }
        public ICollection<DoctorSpeciality>? DoctorSpecialities { get; set; }

    }
}
