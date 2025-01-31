namespace ClinicAPI.Models.DTOs
{
    public class AppointmentResponseDto
    {
        public string AppointmentNumber { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
    }
}