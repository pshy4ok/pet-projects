using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBankAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedBalanceField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "accounts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "accounts");
        }
    }
}
