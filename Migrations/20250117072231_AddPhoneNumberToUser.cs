using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS_API.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNumberToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Users",
                newName: "middleName");

            migrationBuilder.AddColumn<string>(
                name: "mobile",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mobile",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "middleName",
                table: "Users",
                newName: "MiddleName");
        }
    }
}
