using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerApartment.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB_1026_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentType_Building_BuildingID",
                table: "ApartmentType");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentType_BuildingID",
                table: "ApartmentType");

            migrationBuilder.DropColumn(
                name: "BuildingID",
                table: "ApartmentType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingID",
                table: "ApartmentType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentType_BuildingID",
                table: "ApartmentType",
                column: "BuildingID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentType_Building_BuildingID",
                table: "ApartmentType",
                column: "BuildingID",
                principalTable: "Building",
                principalColumn: "BuildingID");
        }
    }
}
