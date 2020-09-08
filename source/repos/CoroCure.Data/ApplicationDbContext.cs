using CoroCure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CoroCure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<FacteursRisqueAntecedants> FacteursRisqueAntecedantss { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Cardiologue> Cardiologues { get; set; }
        public DbSet<Angioplastie> Angioplasties { get; set; }
        public DbSet<Biologie> Biologies { get; set; }
        public DbSet<ContrasteDosimetrie> ContrasteDosimetries { get; set; }
        public DbSet<Coronarographie> Coronarographies { get; set; }
        public DbSet<InterventionMedicale> InterventionMedicales { get; set; }
        public DbSet<Lesion> Lesions { get; set; }
        public DbSet<Traitement> Traitements { get; set; }
        public DbSet<Materiel> Materiels { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Ballon> Ballons { get; set; }
        public DbSet<Stent> Stents { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Description> Descriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=127.0.0.1;Port=5432;Database=CoroCure;User Id=postgres;Password=notasecret;";
            optionsBuilder.UseNpgsql(connectionString, m => m.MigrationsAssembly("CoroCure"));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cardiologue>().ToTable("cardiologue").HasKey(pk => pk.CIN);
            //modelBuilder.Entity<Angioplastie>().ToTable("angioplastie");
            //modelBuilder.Entity<Ballon>().ToTable("ballon");
            //modelBuilder.Entity<Biologie>().ToTable("biologie").HasKey(pk => pk.Id);
            //modelBuilder.Entity<Biologie>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Compte>().ToTable("compte").HasKey(pk => pk.Username);
            modelBuilder.Entity<ContrasteDosimetrie>().ToTable("contrasteDosimetrie").HasKey(pk => pk.Id);
            //modelBuilder.Entity<Coronarographie>().ToTable("coronarographie");
            modelBuilder.Entity<FacteursRisqueAntecedants>().ToTable("facteursRisqueAntecedants").HasKey(pk => pk.Id);
            //modelBuilder.Entity<Guide>().ToTable("guide");
            
            modelBuilder.Entity<InterventionMedicale>()
                        .ToTable("interventionMedicale")
                        .HasKey(pk => pk.Id);

            modelBuilder.Entity<InterventionMedicale>()
                        .Property(e => e.Id)
                        .ValueGeneratedOnAdd();
                        
            modelBuilder.Entity<Lesion>().ToTable("lesion").HasKey(pk => pk.Id);
            modelBuilder.Entity<Materiel>().ToTable("materiel").HasKey(pk => pk.Id);
            modelBuilder.Entity<Patient>().ToTable("patient").HasKey(pk => pk.Id);
            modelBuilder.Entity<Procedure>().ToTable("procedure").HasKey(pk => pk.Id);
            //modelBuilder.Entity<Stent>().ToTable("stent");
            modelBuilder.Entity<Traitement>().ToTable("traitement").HasKey(pk => pk.Id);
            modelBuilder.Entity<Description>().ToTable("description").HasKey(pk => pk.Id);

            //generalisation
            modelBuilder.Entity<Materiel>()
                        .HasDiscriminator<string>("TypeMateriel")
                        .HasValue<Ballon>("Ballon")
                        .HasValue<Stent>("Stent")
                        .HasValue<Guide>("Guide");

            modelBuilder.Entity<InterventionMedicale>()
                        .HasDiscriminator<string>("TypeIntervention")
                        .HasValue<Coronarographie>("Coronarographie")
                        .HasValue<Angioplastie>("Angioplastie");

            //one to one
            modelBuilder.Entity<Cardiologue>()
                        .HasOne(s => s.Compte)
                        .WithOne(ad => ad.Cardiologue)
                        .HasForeignKey<Compte>(ad => ad.CIN)
                        .OnDelete(DeleteBehavior.Cascade);

            /*modelBuilder.Entity<Compte>()
                        .HasOne(s => s.Cardiologue)
                        .WithOne(ad => ad.Compte)
                        .HasForeignKey<Cardiologue>(ad => ad.Username);*/

            modelBuilder.Entity<InterventionMedicale>()
                        .HasOne(s => s.Biologie)
                        .WithOne(ad => ad.InterventionMedicale)
                        .HasForeignKey<InterventionMedicale>(ad => ad.BiologieId)
                        .IsRequired(false);

            modelBuilder.Entity<Coronarographie>()
                        .HasOne(s => s.FacteursRisqueAntecedants)
                        .WithOne(ad => ad.Coronarographie)
                        .HasForeignKey<Coronarographie>(ad => ad.FacteursRisqueAntecedantsId);

            modelBuilder.Entity<Lesion>()
                        .HasOne(s => s.Description)
                        .WithOne(ad => ad.Lesion)
                        .HasForeignKey<Lesion>(ad => ad.DescriptionId);

            modelBuilder.Entity<Coronarographie>()
                        .HasOne(s => s.ContrasteDosimetrie)
                        .WithOne(ad => ad.Coronarographie)
                        .HasForeignKey<Coronarographie>(ad => ad.ContrasteDosimetrieId);

            modelBuilder.Entity<Coronarographie>()
                        .HasOne(s => s.Angioplastie)
                        .WithOne(ad => ad.Coronarographie)
                        .HasForeignKey<Coronarographie>(ad => ad.AngioplastieId)
                        .IsRequired(false);

            //one to many
            modelBuilder.Entity<InterventionMedicale>()
            .HasOne(bc => bc.Cardiologue)
            .WithMany(b => b.InterventionMedicales)
            .HasForeignKey(bc => bc.CIN)
            .IsRequired(false);

            modelBuilder.Entity<InterventionMedicale>()
             .HasOne(bc => bc.Patient)
             .WithMany(b => b.InterventionMedicales)
             .HasForeignKey(bc => bc.PatientId);


            modelBuilder.Entity<Lesion>()
            .HasOne(bc => bc.Coronarographie)
            .WithMany(b => b.Lesions)
            .HasForeignKey(bc => bc.CoronarographieId);

            modelBuilder.Entity<Traitement>()
            .HasOne(bc => bc.Angioplastie)
            .WithMany(b => b.Traitements)
            .HasForeignKey(bc => bc.AngioplastieId);

            modelBuilder.Entity<Ballon>()
            .HasOne(bc => bc.Procedure)
            .WithMany(b => b.Ballons)
            .HasForeignKey(bc => bc.ProcedureId);

            modelBuilder.Entity<Stent>()
            .HasOne(bc => bc.Procedure)
            .WithMany(b => b.Stents)
            .HasForeignKey(bc => bc.ProcedureId);

            modelBuilder.Entity<Guide>()
            .HasOne(bc => bc.Procedure)
            .WithMany(b => b.Guides)
            .HasForeignKey(bc => bc.ProcedureId);

            modelBuilder.Entity<Procedure>()
            .HasOne(bc => bc.Angioplastie)
            .WithMany(b => b.Procedures)
            .HasForeignKey(bc => bc.AngioplastieId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
