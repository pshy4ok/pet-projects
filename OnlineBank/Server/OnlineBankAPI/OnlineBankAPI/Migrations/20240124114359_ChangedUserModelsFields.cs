using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBankAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserModelsFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
