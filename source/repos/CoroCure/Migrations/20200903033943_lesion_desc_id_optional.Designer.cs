﻿// <auto-generated />
using System;
using CoroCure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CoroCure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200903033943_lesion_desc_id_optional")]
    partial class lesion_desc_id_optional
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CoroCure.Data.Entities.Biologie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("CLCreatinine")
                        .HasColumnType("double precision");

                    b.Property<double>("Creatinine")
                        .HasColumnType("double precision");

                    b.Property<double>("Hemoglobine")
                        .HasColumnType("double precision");

                    b.Property<int>("INR")
                        .HasColumnType("integer");

                    b.Property<string>("IRC")
                        .HasColumnType("text");

                    b.Property<int>("PicTroponine")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Biologies");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Cardiologue", b =>
                {
                    b.Property<int>("CIN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("text");

                    b.Property<string>("Prenom")
                        .HasColumnType("text");

                    b.Property<string>("Qualificaction")
                        .HasColumnType("text");

                    b.HasKey("CIN");

                    b.ToTable("cardiologue");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Compte", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<int>("CIN")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.HasIndex("CIN")
                        .IsUnique();

                    b.ToTable("compte");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.ContrasteDosimetrie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("NombreImages")
                        .HasColumnType("integer");

                    b.Property<int>("QtePDC")
                        .HasColumnType("integer");

                    b.Property<int>("QtePDS")
                        .HasColumnType("integer");

                    b.Property<string>("TypePDC")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("contrasteDosimetrie");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Description", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Segment")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("description");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.FacteursRisqueAntecedants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("AIT")
                        .HasColumnType("boolean");

                    b.Property<bool>("ATCDATL")
                        .HasColumnType("boolean");

                    b.Property<bool>("ATCDIDM")
                        .HasColumnType("boolean");

                    b.Property<bool>("ATCDPAC")
                        .HasColumnType("boolean");

                    b.Property<bool>("AVCHem")
                        .HasColumnType("boolean");

                    b.Property<bool>("AVCIsh")
                        .HasColumnType("boolean");

                    b.Property<int>("AncDiabete")
                        .HasColumnType("integer");

                    b.Property<bool>("Diabete")
                        .HasColumnType("boolean");

                    b.Property<bool>("Dysplidemie")
                        .HasColumnType("boolean");

                    b.Property<bool>("HTA")
                        .HasColumnType("boolean");

                    b.Property<double>("IMC")
                        .HasColumnType("double precision");

                    b.Property<string>("Obesite")
                        .HasColumnType("text");

                    b.Property<int>("Poids")
                        .HasColumnType("integer");

                    b.Property<bool>("Tabac")
                        .HasColumnType("boolean");

                    b.Property<double>("Taille")
                        .HasColumnType("double precision");

                    b.Property<string>("TypeDiabete")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("facteursRisqueAntecedants");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.InterventionMedicale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BiologieId")
                        .HasColumnType("integer");

                    b.Property<int>("CIN")
                        .HasColumnType("integer");

                    b.Property<int?>("CardiologueCIN")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnName("DateIntervention")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nom")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<int?>("PatientId")
                        .HasColumnType("integer");

                    b.Property<string>("TypeIntervention")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("estUrgente")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("BiologieId")
                        .IsUnique();

                    b.HasIndex("CardiologueCIN");

                    b.HasIndex("PatientId");

                    b.ToTable("interventionMedicale");

                    b.HasDiscriminator<string>("TypeIntervention").HasValue("InterventionMedicale");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Lesion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CoronarographieId")
                        .HasColumnType("integer");

                    b.Property<double>("Degre")
                        .HasColumnType("double precision");

                    b.Property<int?>("DescriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("FluxTIMI")
                        .HasColumnType("integer");

                    b.Property<string>("TypeLesion")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CoronarographieId");

                    b.HasIndex("DescriptionId")
                        .IsUnique();

                    b.ToTable("lesion");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Materiel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AngioplastieId")
                        .HasColumnType("integer");

                    b.Property<string>("CGReseauD")
                        .HasColumnType("text");

                    b.Property<string>("CGReseauG")
                        .HasColumnType("text");

                    b.Property<string>("Pontage")
                        .HasColumnType("text");

                    b.Property<int>("TailleDesilet")
                        .HasColumnType("integer");

                    b.Property<string>("TypeMateriel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AngioplastieId");

                    b.ToTable("materiel");

                    b.HasDiscriminator<string>("TypeMateriel").HasValue("Materiel");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Adresse")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NSS")
                        .HasColumnType("text");

                    b.Property<string>("Nom")
                        .HasColumnType("text");

                    b.Property<string>("Prenom")
                        .HasColumnType("text");

                    b.Property<string>("Sexe")
                        .HasColumnType("text");

                    b.Property<string>("Tel")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("patient");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AngioplastieId")
                        .HasColumnType("integer");

                    b.Property<string>("Resultat")
                        .HasColumnType("text");

                    b.Property<int>("TIMIFinal")
                        .HasColumnType("integer");

                    b.Property<string>("Technique")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AngioplastieId");

                    b.ToTable("procedure");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Traitement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AngioplastieId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnName("DateTraitement")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nom")
                        .HasColumnType("text");

                    b.Property<int>("Posologie")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AngioplastieId");

                    b.ToTable("traitement");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Angioplastie", b =>
                {
                    b.HasBaseType("CoroCure.Data.Entities.InterventionMedicale");

                    b.Property<string>("AbordArterielPrincipal")
                        .HasColumnType("text");

                    b.Property<int>("AntiGIIBIIIQte")
                        .HasColumnType("integer");

                    b.Property<int>("AnticaogulantIVQte")
                        .HasColumnType("integer");

                    b.Property<string>("AnticoagulantIV")
                        .HasColumnType("text");

                    b.Property<int>("FreqCardique")
                        .HasColumnType("integer");

                    b.Property<int>("LoxenQte")
                        .HasColumnType("integer");

                    b.Property<int>("PADiastolique")
                        .HasColumnType("integer");

                    b.Property<int>("PASystolique")
                        .HasColumnType("integer");

                    b.Property<int>("RisordanQte")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("Angioplastie");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Coronarographie", b =>
                {
                    b.HasBaseType("CoroCure.Data.Entities.InterventionMedicale");

                    b.Property<int>("AngioplastieId")
                        .HasColumnType("integer");

                    b.Property<string>("AutreMotif")
                        .HasColumnType("text");

                    b.Property<int>("ContrasteDosimetrieId")
                        .HasColumnType("integer");

                    b.Property<int>("FacteursRisqueAntecedantsId")
                        .HasColumnType("integer");

                    b.Property<double>("FeVG")
                        .HasColumnType("double precision");

                    b.Property<string>("MotifPrinc")
                        .HasColumnType("text");

                    b.Property<string>("Statut")
                        .HasColumnType("text");

                    b.Property<string>("Voie")
                        .HasColumnType("text");

                    b.HasIndex("AngioplastieId")
                        .IsUnique();

                    b.HasIndex("ContrasteDosimetrieId")
                        .IsUnique();

                    b.HasIndex("FacteursRisqueAntecedantsId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("Coronarographie");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Ballon", b =>
                {
                    b.HasBaseType("CoroCure.Data.Entities.Materiel");

                    b.Property<int>("Diametre")
                        .HasColumnType("integer");

                    b.Property<int>("Longueur")
                        .HasColumnType("integer");

                    b.Property<string>("Phase")
                        .HasColumnType("text");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasIndex("ProcedureId");

                    b.HasDiscriminator().HasValue("Ballon");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Guide", b =>
                {
                    b.HasBaseType("CoroCure.Data.Entities.Materiel");

                    b.Property<int>("ProcedureId")
                        .HasColumnName("Guide_ProcedureId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnName("Guide_Type")
                        .HasColumnType("text");

                    b.HasIndex("ProcedureId");

                    b.HasDiscriminator().HasValue("Guide");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Stent", b =>
                {
                    b.HasBaseType("CoroCure.Data.Entities.Materiel");

                    b.Property<int>("Diametre")
                        .HasColumnName("Stent_Diametre")
                        .HasColumnType("integer");

                    b.Property<int>("DureeInf")
                        .HasColumnType("integer");

                    b.Property<int>("Longueur")
                        .HasColumnName("Stent_Longueur")
                        .HasColumnType("integer");

                    b.Property<string>("Marque")
                        .HasColumnType("text");

                    b.Property<int>("PressionInf")
                        .HasColumnType("integer");

                    b.Property<int>("ProcedureId")
                        .HasColumnName("Stent_ProcedureId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnName("Stent_Type")
                        .HasColumnType("text");

                    b.HasIndex("ProcedureId");

                    b.HasDiscriminator().HasValue("Stent");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Compte", b =>
                {
                    b.HasOne("CoroCure.Data.Entities.Cardiologue", "Cardiologue")
                        .WithOne("Compte")
                        .HasForeignKey("CoroCure.Data.Entities.Compte", "CIN");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.InterventionMedicale", b =>
                {
                    b.HasOne("CoroCure.Data.Entities.Biologie", "Biologie")
                        .WithOne("InterventionMedicale")
                        .HasForeignKey("CoroCure.Data.Entities.InterventionMedicale", "BiologieId");

                    b.HasOne("CoroCure.Data.Entities.Cardiologue", "Cardiologue")
                        .WithMany("InterventionMedicales")
                        .HasForeignKey("CardiologueCIN");

                    b.HasOne("CoroCure.Data.Entities.Patient", "Patient")
                        .WithMany("InterventionMedicales")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Lesion", b =>
                {
                    b.HasOne("CoroCure.Data.Entities.Coronarographie", "Coronarographie")
                        .WithMany("Lesions")
                        .HasForeignKey("CoronarographieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoroCure.Data.Entities.Description", "Description")
                        .WithOne("Lesion")
                        .HasForeignKey("CoroCure.Data.Entities.Lesion", "DescriptionId");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Materiel", b =>
                {
                    b.HasOne("CoroCure.Data.Entities.Angioplastie", "Angioplastie")
                        .WithMany("Materiels")
                        .HasForeignKey("AngioplastieId");
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Procedure", b =>
                {
                    b.HasOne("CoroCure.Data.Entities.Angioplastie", "Angioplastie")
                        .WithMany("Procedures")
                        .HasForeignKey("AngioplastieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Traitement", b =>
                {
                    b.HasOne("CoroCure.Data.Entities.Angioplastie", "Angioplastie")
                        .WithMany("Traitements")
                        .HasForeignKey("AngioplastieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Coronarographie", b =>
                {
                    b.HasOne("CoroCure.Data.Entities.Angioplastie", "Angioplastie")
                        .WithOne("Coronarographie")
                        .HasForeignKey("CoroCure.Data.Entities.Coronarographie", "AngioplastieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoroCure.Data.Entities.ContrasteDosimetrie", "ContrasteDosimetrie")
                        .WithOne("Coronarographie")
                        .HasForeignKey("CoroCure.Data.Entities.Coronarographie", "ContrasteDosimetrieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoroCure.Data.Entities.FacteursRisqueAntecedants", "FacteursRisqueAntecedants")
                        .WithOne("Coronarographie")
                        .HasForeignKey("CoroCure.Data.Entities.Coronarographie", "FacteursRisqueAntecedantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Ballon", b =>
                {
                    b.HasOne("CoroCure.Data.Entities.Procedure", "Procedure")
                        .WithMany("Ballons")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Guide", b =>
                {
                    b.HasOne("CoroCure.Data.Entities.Procedure", "Procedure")
                        .WithMany("Guides")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoroCure.Data.Entities.Stent", b =>
                {
                    b.HasOne("CoroCure.Data.Entities.Procedure", "Procedure")
                        .WithMany("Stents")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
