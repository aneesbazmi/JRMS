using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JRMS.Migrations
{
    /// <inheritdoc />
    public partial class DbCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applicants",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email_Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Marks_In_Matriculation = table.Column<int>(type: "int", nullable: true),
                    Marks_In_Intermediate = table.Column<int>(type: "int", nullable: true),
                    Marks_In_Batchelor = table.Column<int>(type: "int", nullable: true),
                    Applicant_Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicants", x => x.ApplicantId);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Dept_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Dept_Id);
                });

            migrationBuilder.CreateTable(
                name: "black_listed_candidates",
                columns: table => new
                {
                    Black_Listed_CandidatesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_black_listed_candidates", x => x.Black_Listed_CandidatesId);
                    table.ForeignKey(
                        name: "FK_black_listed_candidates_applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "applicants",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "job",
                columns: table => new
                {
                    Job_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Jobb_Adverstisement_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Job_Dept_Id = table.Column<int>(type: "int", nullable: false),
                    Job_Last_Date_Apply = table.Column<DateTime>(type: "date", nullable: false),
                    Job_Scale = table.Column<byte>(type: "tinyint", nullable: false),
                    Job_Total_Seats = table.Column<byte>(type: "tinyint", nullable: false),
                    Total_Women_Seats = table.Column<byte>(type: "tinyint", nullable: false),
                    Total_Open_Merit_Seats = table.Column<byte>(type: "tinyint", nullable: false),
                    Job_Result_Declaration_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Job_Posting_City_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Is_Contract_Based = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job", x => x.Job_Id);
                    table.ForeignKey(
                        name: "FK_job_departments_Job_Dept_Id",
                        column: x => x.Job_Dept_Id,
                        principalTable: "departments",
                        principalColumn: "Dept_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "job_application",
                columns: table => new
                {
                    Application_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_Id = table.Column<int>(type: "int", nullable: false),
                    Applicant_Id = table.Column<int>(type: "int", nullable: false),
                    Job_Application_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Payment_Method = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Payment_Amount = table.Column<int>(type: "int", nullable: true),
                    Job_Id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_application", x => x.Application_Id);
                    table.ForeignKey(
                        name: "FK_job_application_applicants_Applicant_Id",
                        column: x => x.Applicant_Id,
                        principalTable: "applicants",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_job_application_job_Job_Id1",
                        column: x => x.Job_Id1,
                        principalTable: "job",
                        principalColumn: "Job_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "job_result",
                columns: table => new
                {
                    Job_Result_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Applicant_Id = table.Column<int>(type: "int", nullable: false),
                    Job_Id = table.Column<int>(type: "int", nullable: false),
                    Obtained_Marks_In_Test = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Obtained_Marks_In_Interview = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total_Marks_Out_Of_200 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_result", x => x.Job_Result_Id);
                    table.ForeignKey(
                        name: "FK_job_result_job_Job_Id",
                        column: x => x.Job_Id,
                        principalTable: "job",
                        principalColumn: "Job_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_black_listed_candidates_ApplicantId",
                table: "black_listed_candidates",
                column: "ApplicantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_job_Job_Dept_Id",
                table: "job",
                column: "Job_Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_job_application_Applicant_Id",
                table: "job_application",
                column: "Applicant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_job_application_Job_Id1",
                table: "job_application",
                column: "Job_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_job_result_Job_Id",
                table: "job_result",
                column: "Job_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "black_listed_candidates");

            migrationBuilder.DropTable(
                name: "job_application");

            migrationBuilder.DropTable(
                name: "job_result");

            migrationBuilder.DropTable(
                name: "applicants");

            migrationBuilder.DropTable(
                name: "job");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
