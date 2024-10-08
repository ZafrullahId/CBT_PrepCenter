using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBTPreparation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ddd_admin_user1_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                schema: "cbtprep",
                table: "Admins",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserId",
                schema: "cbtprep",
                table: "Admins",
                column: "UserId",
                principalSchema: "cbtprep",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserId",
                schema: "cbtprep",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UserId",
                schema: "cbtprep",
                table: "Admins");
        }
    }
}
