using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTest.Models.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TestId",
                table: "Questions");
        }
    }
}
