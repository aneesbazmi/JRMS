using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JRMS.Migrations
{
    /// <inheritdoc />
    public partial class dbUpadate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "job_result",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_job_result_ApplicantId",
                table: "job_result",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_job_result_applicants_ApplicantId",
                table: "job_result",
                column: "ApplicantId",
                principalTable: "applicants",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_result_applicants_ApplicantId",
                table: "job_result");

            migrationBuilder.DropIndex(
                name: "IX_job_result_ApplicantId",
                table: "job_result");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "job_result");
        }
    }
}
