namespace ClinicAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public decimal Phone { get; set; }
        public string Status { get; set; } = string.Empty;
        public ICollection<Appointment>? Appointments { get; set; }
        public User? User { get; set; }
    }
}
