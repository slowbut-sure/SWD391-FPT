using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerApartment.Migrations
{
    /// <inheritdoc />
    public partial class DropStafflog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffLog");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "RequestLog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RequestLog_StaffId",
                table: "RequestLog",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK__RequestLo__Staff__628FA481",
                table: "RequestLog",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__RequestLo__Staff__628FA481",
                table: "RequestLog");

            migrationBuilder.DropIndex(
                name: "IX_RequestLog_StaffId",
                table: "RequestLog");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "RequestLog");

            migrationBuilder.CreateTable(
                name: "StaffLog",
                columns: table => new
                {
                    StaffLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestLogID = table.Column<int>(type: "int", nullable: true),
                    StaffID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StaffLog__511DAB3CA2BD394C", x => x.StaffLogID);
                    table.ForeignKey(
                        name: "FK__StaffLog__Reques__693CA210",
                        column: x => x.RequestLogID,
                        principalTable: "RequestLog",
                        principalColumn: "RequestLogID");
                    table.ForeignKey(
                        name: "FK__StaffLog__StaffI__68487DD7",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffLog_RequestLogID",
                table: "StaffLog",
                column: "RequestLogID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLog_StaffID",
                table: "StaffLog",
                column: "StaffID");
        }
    }
}
