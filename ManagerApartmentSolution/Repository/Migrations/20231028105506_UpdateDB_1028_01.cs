using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerApartment.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB_1028_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestDetail");

            migrationBuilder.AddColumn<int>(
                name: "PackageID",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Request_PackageID",
                table: "Request",
                column: "PackageID");

            migrationBuilder.AddForeignKey(
                name: "FK__Request__Packg__61B365L6",
                table: "Request",
                column: "PackageID",
                principalTable: "Package",
                principalColumn: "PackageID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Request__Packg__61B365L6",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_PackageID",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "PackageID",
                table: "Request");

            migrationBuilder.CreateTable(
                name: "RequestDetail",
                columns: table => new
                {
                    RequestDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageID = table.Column<int>(type: "int", nullable: true),
                    RequestID = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RequestD__DC528B7058AD6952", x => x.RequestDetailID);
                    table.ForeignKey(
                        name: "FK__RequestDe__Packa__6D0D32F4",
                        column: x => x.PackageID,
                        principalTable: "Package",
                        principalColumn: "PackageID");
                    table.ForeignKey(
                        name: "FK__RequestDe__Reque__6C190EBB",
                        column: x => x.RequestID,
                        principalTable: "Request",
                        principalColumn: "RequestID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetail_PackageID",
                table: "RequestDetail",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetail_RequestID",
                table: "RequestDetail",
                column: "RequestID");
        }
    }
}
