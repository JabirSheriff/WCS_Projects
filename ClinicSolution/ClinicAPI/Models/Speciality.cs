namespace ClinicAPI.Models
{
    public class Speciality
    {
        public int Id{ get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<DoctorSpeciality>? Specialities { get; set; }
    }
}
