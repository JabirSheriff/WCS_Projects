namespace ClinicAPI.Models.DTOs
{
    public class PatientUpdateRequestDto
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public decimal? Phone { get; set; }
        public int? Age { get; set; }
    }
}