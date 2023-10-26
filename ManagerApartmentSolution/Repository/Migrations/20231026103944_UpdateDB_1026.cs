using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerApartment.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB_1026 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Apartment__Build__3D5E1FD2",
                table: "ApartmentType");

            migrationBuilder.AddColumn<string>(
                name: "AvatarLink",
                table: "Tennant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "Tennant",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Tennant",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "Staff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Staff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarLink",
                table: "Owner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "Owner",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Owner",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApartmentName",
                table: "Apartment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentType_Building_BuildingID",
                table: "ApartmentType",
                column: "BuildingID",
                principalTable: "Building",
                principalColumn: "BuildingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentType_Building_BuildingID",
                table: "ApartmentType");

            migrationBuilder.DropColumn(
                name: "AvatarLink",
                table: "Tennant");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "Tennant");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Tennant");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "AvatarLink",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "ApartmentName",
                table: "Apartment");

            migrationBuilder.AddForeignKey(
                name: "FK__Apartment__Build__3D5E1FD2",
                table: "ApartmentType",
                column: "BuildingID",
                principalTable: "Building",
                principalColumn: "BuildingID");
        }
    }
}
