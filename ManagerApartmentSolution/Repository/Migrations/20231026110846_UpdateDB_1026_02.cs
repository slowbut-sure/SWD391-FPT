using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerApartment.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB_1026_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PackageImageLink",
                table: "Package",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContractNumber",
                table: "Apartment",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageImageLink",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "ContractNumber",
                table: "Apartment");
        }
    }
}
