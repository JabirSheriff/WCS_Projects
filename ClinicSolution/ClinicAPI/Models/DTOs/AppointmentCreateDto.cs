namespace ClinicAPI.Models.DTOs
{
    public class AppointmentCreateDto
    {
        public int PatientId { get; set; }
        public string DoctorNumber { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Remarks { get; set; } = string.Empty;
    }
}