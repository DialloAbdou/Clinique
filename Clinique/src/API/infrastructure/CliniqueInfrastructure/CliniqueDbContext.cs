using CliniqueDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace CliniqueInfrastructure
{
    public class CliniqueDbContext:DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Maladie> Maladies { get; set;}
        public DbSet<Soin> Soins { get; set; }
        public DbSet<Traitement> Traitements { get; set; }

        public CliniqueDbContext(DbContextOptions<CliniqueDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(p =>
            {
                p.ToTable("Patients");
                p.Property(p=>p.Nom).IsRequired();
                p.Property(p => p.Prenom);
                p.Property(p => p.Adresse);
                p.Property(p => p.Age);

                p.HasOne(p=>p.Medecin)
                .WithMany(m=>m.Patients)
                .HasForeignKey(p=>p.MedecinId);

                p.HasOne(p => p.Maladie)
                .WithMany(m => m.Patients)
                .HasForeignKey(p => p.MaladieId);


            });
            modelBuilder.Entity<Medecin>(m =>
            {
                m.ToTable("Medecin");
                m.Property(m=>m.Nom).IsRequired();
                m.Property(m => m.Prenom);
                m.Property(m => m.Adresse);
                m.Property(m => m.Age);
                m.Property(m => m.Token).HasMaxLength(16);
                m.HasMany(m => m.Patients)
                .WithOne(p => p.Medecin)
                .HasForeignKey(p=>p.MedecinId);
                m.HasIndex(m => m.Token).IsUnique();

                
            });
            modelBuilder.Entity<Maladie>(m =>
            {
                m.ToTable("Maladies");
                m.Property(m => m.Pathologie).IsRequired();
                m.HasMany(m => m.Patients)
                .WithOne(p => p.Maladie)
                .HasForeignKey(p=>p.MaladieId);

            });
            modelBuilder.Entity<Soin>(s =>
            {
                s.ToTable("Soins");
                s.Property(s => s.TypeSoin).IsRequired();
                s.Property(s => s.Durees).IsRequired();
                s.Property(s => s.prix).IsRequired();
                s.HasMany(s => s.Maladies)
                .WithMany(m => m.Soins)
                .UsingEntity<Traitement>
                (t => t
                .HasKey(t => new { t.SoinId, t.MaladieId }));



            });


            // Initialisation Base de Donnée
            ////Init Maladie

            //modelBuilder.Entity<Maladie>().HasData(new Maladie { Id = 1, Pathologie = "scarlatine" });
            //modelBuilder.Entity<Maladie>().HasData(new Maladie { Id = 2, Pathologie = "Varicelle" });
            //modelBuilder.Entity<Maladie>().HasData(new Maladie { Id = 3, Pathologie = "Tuberculose" });
            //modelBuilder.Entity<Maladie>().HasData(new Maladie { Id = 4, Pathologie = "Covid" });
            //modelBuilder.Entity<Maladie>().HasData(new Maladie { Id = 5, Pathologie = "Grippe" });
            //modelBuilder.Entity<Maladie>().HasData(new Maladie { Id = 6, Pathologie = "Rhume" });
            //modelBuilder.Entity<Maladie>().HasData(new Maladie { Id = 7, Pathologie = "Oreillon" });

            //// init Medecin
            //modelBuilder.Entity<Medecin>().HasData(new Medecin { Id = 1, Nom = "Medecin1" });
            //modelBuilder.Entity<Medecin>().HasData(new Medecin { Id = 2, Nom = "Medecin2" });

            //// //// Init Patient
            //modelBuilder.Entity<Patient>().HasData(new Patient { Id = 1, MaladieId = 1, Nom = "Patient1", MedecinId = 1 });
            //modelBuilder.Entity<Patient>().HasData(new Patient { Id = 2, MaladieId = 1, Nom = "Patient2", MedecinId = 1 });
            //modelBuilder.Entity<Patient>().HasData(new Patient { Id = 3, MaladieId = 2, Nom = "Patient3", MedecinId = 1 });
            //modelBuilder.Entity<Patient>().HasData(new Patient { Id = 4, MaladieId = 3, Nom = "Patient4", MedecinId = 1 });
            //modelBuilder.Entity<Patient>().HasData(new Patient { Id = 5, MaladieId = 4, Nom = "Patient5", MedecinId = 1 });
            //modelBuilder.Entity<Patient>().HasData(new Patient { Id = 6, MaladieId = 4, Nom = "Patient6", MedecinId = 1 });
            //modelBuilder.Entity<Patient>().HasData(new Patient { Id = 7, MaladieId = 5, Nom = "Patient7", MedecinId = 2 });
            //modelBuilder.Entity<Patient>().HasData(new Patient { Id = 8, MaladieId = 6, Nom = "Patient8", MedecinId = 2 });
            //modelBuilder.Entity<Patient>().HasData(new Patient { Id = 9, MaladieId = 7, Nom = "Patient9", MedecinId = 2 });
            //modelBuilder.Entity<Patient>().HasData(new Patient { Id = 10, MaladieId = 7, Nom = "Patient10", MedecinId = 2 });


            //modelBuilder.Entity<Soin>().HasData(new Soin { Id = 1, TypeSoin = "soin1", prix = 50, Durees = 1 });
            //modelBuilder.Entity<Soin>().HasData(new Soin { Id = 2, TypeSoin = "soin2", prix = 100, Durees = 2 });
            //modelBuilder.Entity<Soin>().HasData(new Soin { Id = 3, TypeSoin = "soin3", prix = 150, Durees = 3 });
            //modelBuilder.Entity<Soin>().HasData(new Soin { Id = 4, TypeSoin = "soin4", prix = 200, Durees = 5 });


            //modelBuilder.Entity<Traitement>().HasData(new Traitement { SoinId = 1, MaladieId = 1 });
            //modelBuilder.Entity<Traitement>().HasData(new Traitement { SoinId = 2, MaladieId = 1 });
            //modelBuilder.Entity<Traitement>().HasData(new Traitement { SoinId = 3, MaladieId = 2 });
            //modelBuilder.Entity<Traitement>().HasData(new Traitement { SoinId = 1, MaladieId = 3 });
            //modelBuilder.Entity<Traitement>().HasData(new Traitement { SoinId = 3, MaladieId = 3 });
            //modelBuilder.Entity<Traitement>().HasData(new Traitement { SoinId = 4, MaladieId = 3 });
            //modelBuilder.Entity<Traitement>().HasData(new Traitement { SoinId = 2, MaladieId = 4 });
            //modelBuilder.Entity<Traitement>().HasData(new Traitement { SoinId = 4, MaladieId = 4 });
            //modelBuilder.Entity<Traitement>().HasData(new Traitement { SoinId = 3, MaladieId = 5 });
            //modelBuilder.Entity<Traitement>().HasData(new Traitement { SoinId = 4, MaladieId = 5 });
            //modelBuilder.Entity<Traitement>().HasData(new Traitement { SoinId = 1, MaladieId = 6 });
            //modelBuilder.Entity<Traitement>().HasData(new Traitement { SoinId = 2, MaladieId = 7 });
        }

    }
}
