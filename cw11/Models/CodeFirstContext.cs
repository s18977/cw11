using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace cw11.Models
{
    public class CodeFirstContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<PrescrpitionMedicament> PrescrpitionMedicaments { get; set; }

        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var patientList = new List<Patient>();
            patientList.Add(new Patient { IdPatient = 1, FirstName = "Bartłomiej", LastName = "Stocki", BirthDate = new System.DateTime(1890, 12, 24) });
            patientList.Add(new Patient { IdPatient = 2, FirstName = "Andrzej", LastName = "Gołota", BirthDate = new System.DateTime(1999, 1, 31) });

            var doctorList = new List<Doctor>();
            doctorList.Add(new Doctor { IdDoctor = 1, FirstName = "Bartłomiej", LastName = "Stocki", Email = "bartus@gmail.com" });
            doctorList.Add(new Doctor { IdDoctor = 2, FirstName = "Andrzej", LastName = "Gołota", Email = "andrzejek@gmail.com" });

            var presList = new List<Prescription>();
            presList.Add(new Prescription { IdPrescription = 1, Date = new System.DateTime(2020, 2, 27), DueDate = new System.DateTime(2020, 3, 27), IdDoctor = 1, IdPatient = 2 });
            presList.Add(new Prescription { IdPrescription = 2, Date = new System.DateTime(2020, 2, 27), DueDate = new System.DateTime(2020, 3, 27), IdDoctor = 2, IdPatient = 1 });

            var medList = new List<Medicament>();
            medList.Add(new Medicament { IdMedicament = 1, Description = "No ibuprofent to co ma robic", Name = "Ibuprofen", Type = "Biała piguła" });
            medList.Add(new Medicament { IdMedicament = 2, Description = "Witaminka C", Name = "Rutinoscorbin", Type = "Zółta piguła" });

            var presMedList = new List<PrescrpitionMedicament>();
            presMedList.Add(new PrescrpitionMedicament { IdMedicament = 1, Details = "Tradzik", Dose = 2, IdPrescription = 1 });
            presMedList.Add(new PrescrpitionMedicament { IdMedicament = 2, Details = "Katar", Dose = 4, IdPrescription = 2 });

            modelBuilder.Entity<Patient>(entity => {
                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");
                entity.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired();

                entity.HasData(patientList);
            
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
                entity.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(30).IsRequired();

                entity.HasData(doctorList);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");

                entity.Property(e => e.IdPrescription).ValueGeneratedNever();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(p => p.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Patient");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(p => p.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Doctor");

                entity.HasData(presList);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament).HasName("Medicament_PK");

                entity.Property(e => e.Name).HasMaxLength(30).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(30).IsRequired();

                entity.HasData(medList);
            });

            modelBuilder.Entity<PrescrpitionMedicament>(entity =>
            {
                entity.ToTable("Prescrpition_Medicament");

                entity.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
                entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
                entity.Property(e => e.Dose);
                entity.Property(e => e.Details).HasMaxLength(100).IsRequired();

                entity.HasOne(e => e.Medicament)
                      .WithMany(pm => pm.PrescriptionsMedicament)
                      .HasForeignKey(pm => pm.IdMedicament)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Prescription_Medicament_Medicament");

                entity.HasOne(e => e.Prescription)
                      .WithMany(pm => pm.PrescriptionsMedicament)
                      .HasForeignKey(pm => pm.IdPrescription)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Prescription_Medicament_Prescription");

                entity.HasData(presMedList);
            });
        }
    }
}
