namespace ClinicAPI.Models
{
    public class DoctorSpeciality
    {
        public int Id{ get; set; }
        public string DoctorNumber { get; set; }=string.Empty;
        public int SpecilityId { get; set; }
        public Doctor Doctor { get; set; } = new Doctor();
        public Speciality Speciality { get; set; } = new Speciality();
    }
}
