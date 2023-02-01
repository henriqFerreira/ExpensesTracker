using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTracker.DAO.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdAspNetUser",
                table: "User",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdAspNetUser",
                table: "User",
                column: "IdAspNetUser",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_AspNetUsers_IdAspNetUser",
                table: "User",
                column: "IdAspNetUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_AspNetUsers_IdAspNetUser",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdAspNetUser",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "IdAspNetUser",
                table: "User",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
