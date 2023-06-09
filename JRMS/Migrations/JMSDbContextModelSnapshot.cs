﻿// <auto-generated />
using System;
using JRMS.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JRMS.Migrations
{
    [DbContext(typeof(JMSDbContext))]
    partial class JMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityFramework.Applicant", b =>
                {
                    b.Property<int>("ApplicantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicantId"));

                    b.Property<string>("Applicant_Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Email_Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Marks_In_Batchelor")
                        .HasColumnType("int");

                    b.Property<int?>("Marks_In_Intermediate")
                        .HasColumnType("int");

                    b.Property<int?>("Marks_In_Matriculation")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("date_of_birth")
                        .HasColumnType("date");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ApplicantId");

                    b.ToTable("applicants");
                });

            modelBuilder.Entity("EntityFramework.Black_Listed_Candidates", b =>
                {
                    b.Property<int>("Black_Listed_CandidatesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Black_Listed_CandidatesId"));

                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.HasKey("Black_Listed_CandidatesId");

                    b.HasIndex("ApplicantId")
                        .IsUnique();

                    b.ToTable("black_listed_candidates");
                });

            modelBuilder.Entity("EntityFramework.Department", b =>
                {
                    b.Property<int>("Dept_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dept_Id"));

                    b.Property<string>("Dept_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Dept_Id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("EntityFramework.Job", b =>
                {
                    b.Property<int>("Job_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Job_Id"));

                    b.Property<byte>("Is_Contract_Based")
                        .HasColumnType("tinyint");

                    b.Property<int>("Job_Dept_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Job_Last_Date_Apply")
                        .HasColumnType("date");

                    b.Property<string>("Job_Posting_City_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Job_Result_Declaration_Date")
                        .HasColumnType("date");

                    b.Property<byte>("Job_Scale")
                        .HasColumnType("tinyint");

                    b.Property<string>("Job_Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Job_Total_Seats")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("Jobb_Adverstisement_Date")
                        .HasColumnType("date");

                    b.Property<byte>("Total_Open_Merit_Seats")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Total_Women_Seats")
                        .HasColumnType("tinyint");

                    b.HasKey("Job_Id");

                    b.HasIndex("Job_Dept_Id");

                    b.ToTable("job");
                });

            modelBuilder.Entity("EntityFramework.Job_Application", b =>
                {
                    b.Property<int>("Application_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Application_Id"));

                    b.Property<int>("Applicant_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Job_Application_Date")
                        .HasColumnType("date");

                    b.Property<int>("Job_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Payment_Amount")
                        .HasColumnType("int");

                    b.Property<string>("Payment_Method")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Application_Id");

                    b.HasIndex("Applicant_Id");

                    b.HasIndex("Job_Id");

                    b.ToTable("job_application");
                });

            modelBuilder.Entity("EntityFramework.Job_Result", b =>
                {
                    b.Property<int>("Job_Result_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Job_Result_Id"));

                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<int>("Applicant_Id")
                        .HasColumnType("int");

                    b.Property<int>("Job_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Obtained_Marks_In_Interview")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Obtained_Marks_In_Test")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Total_Marks_Out_Of_200")
                        .HasColumnType("int");

                    b.HasKey("Job_Result_Id");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("Job_Id");

                    b.ToTable("job_result");
                });

            modelBuilder.Entity("EntityFramework.Black_Listed_Candidates", b =>
                {
                    b.HasOne("EntityFramework.Applicant", "Applicant")
                        .WithOne("Black_Listed_Candidate")
                        .HasForeignKey("EntityFramework.Black_Listed_Candidates", "ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("EntityFramework.Job", b =>
                {
                    b.HasOne("EntityFramework.Department", "Department")
                        .WithMany("Jobs")
                        .HasForeignKey("Job_Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EntityFramework.Job_Application", b =>
                {
                    b.HasOne("EntityFramework.Applicant", "Applicant")
                        .WithMany("Job_Application")
                        .HasForeignKey("Applicant_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework.Job", "Job")
                        .WithMany("Job_Application")
                        .HasForeignKey("Job_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("EntityFramework.Job_Result", b =>
                {
                    b.HasOne("EntityFramework.Applicant", "applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework.Job", "Job")
                        .WithMany("Job_Result")
                        .HasForeignKey("Job_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("applicant");
                });

            modelBuilder.Entity("EntityFramework.Applicant", b =>
                {
                    b.Navigation("Black_Listed_Candidate")
                        .IsRequired();

                    b.Navigation("Job_Application");
                });

            modelBuilder.Entity("EntityFramework.Department", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("EntityFramework.Job", b =>
                {
                    b.Navigation("Job_Application");

                    b.Navigation("Job_Result");
                });
#pragma warning restore 612, 618
        }
    }
}
