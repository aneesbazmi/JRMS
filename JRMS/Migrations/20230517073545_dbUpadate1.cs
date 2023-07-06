using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JRMS.Migrations
{
    /// <inheritdoc />
    public partial class dbUpadate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_application_job_Job_Id1",
                table: "job_application");

            migrationBuilder.DropIndex(
                name: "IX_job_application_Job_Id1",
                table: "job_application");

            migrationBuilder.DropColumn(
                name: "Job_Id1",
                table: "job_application");

            migrationBuilder.CreateIndex(
                name: "IX_job_application_Job_Id",
                table: "job_application",
                column: "Job_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_job_application_job_Job_Id",
                table: "job_application",
                column: "Job_Id",
                principalTable: "job",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_application_job_Job_Id",
                table: "job_application");

            migrationBuilder.DropIndex(
                name: "IX_job_application_Job_Id",
                table: "job_application");

            migrationBuilder.AddColumn<int>(
                name: "Job_Id1",
                table: "job_application",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_job_application_Job_Id1",
                table: "job_application",
                column: "Job_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_job_application_job_Job_Id1",
                table: "job_application",
                column: "Job_Id1",
                principalTable: "job",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
