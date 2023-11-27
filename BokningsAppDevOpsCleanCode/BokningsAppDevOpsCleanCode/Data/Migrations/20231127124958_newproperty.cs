using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BokningsAppDevOpsCleanCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class newproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChosenTime",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChosenTime",
                table: "Bookings");
        }
    }
}
