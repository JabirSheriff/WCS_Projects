namespace ClinicAPI.Models
{
    public class Appointment
    {
        public string AppointmentNumber { get; set; } = string.Empty;
        public string DoctorNumber { get; set; } = string.Empty;
        public int PatientId { get; set; } 
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "Pending";
        public string? Remarks { get; set; }
        public Patient Patient { get; set; } = new Patient();
        public Doctor Doctor { get; set; } = new Doctor();
    }
}
