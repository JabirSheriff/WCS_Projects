using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Contexts
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<DoctorSpeciality> DoctorSpecialities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speciality>().HasData(SeedSpecialities());
            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorNumber);
            modelBuilder.Entity<User>().HasKey(u => u.Email);
            modelBuilder.Entity<Appointment>().HasKey(a => a.AppointmentNumber);

            modelBuilder.Entity<User>().HasOne(p => p.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<Patient>(p => p.Email)
                .HasConstraintName("FK_Patient_User")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasOne(p => p.Doctor)
                .WithOne(d => d.User)
                .HasForeignKey<Doctor>(d => d.Email)
                .HasConstraintName("FK_Doctor_User")
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DoctorSpeciality>().HasOne(d => d.Speciality)
                .WithMany(ds => ds.Specialities)
                .HasForeignKey(d => d.SpecilityId)
                .HasConstraintName("FK_DoctorSpeciality_Specality")
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DoctorSpeciality>().HasOne(d => d.Doctor)
               .WithMany(ds => ds.DoctorSpecialities)
               .HasForeignKey(d => d.DoctorNumber)
               .HasConstraintName("FK_DoctorSpeciality_Doctor")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>().HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .HasConstraintName("FK_Appointment_Patient")
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>().HasOne(a => a.Doctor)
             .WithMany(d => d.Appointments)
             .HasForeignKey(a => a.DoctorNumber)
             .HasConstraintName("FK_Appointment_Doctor")
              .OnDelete(DeleteBehavior.Restrict);

        }


        List<Speciality> SeedSpecialities()
        {
            return (new List<Speciality> { new Speciality
                {
                    Id = 1,
                    Name = "Cardiologist"
                },
                new Speciality
                {
                    Id = 2,
                    Name = "Dermatologist"
                },
                new Speciality
                {
                    Id = 3,
                    Name = "Endocrinologist"
                },
                new Speciality
                {
                    Id = 4,
                    Name = "Gastroenterologist"
                },
                new Speciality
                {
                    Id = 5,
                    Name = "Hematologist"
                },
                new Speciality
                {
                    Id = 6,
                    Name = "Neurologist"
                },
                new Speciality
                {
                    Id = 7,
                    Name = "Oncologist"
                }});
        }
    }
}
