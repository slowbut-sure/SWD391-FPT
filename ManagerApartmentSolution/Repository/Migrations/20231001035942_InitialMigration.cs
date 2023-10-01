using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerApartment.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetHistory",
                columns: table => new
                {
                    AssetHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    ItemImage = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AssetHis__5681DDEDE33267A7", x => x.AssetHistoryID);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Building__5463CDE4564BE5EA", x => x.BuildingID);
                });

            migrationBuilder.CreateTable(
                name: "ContractDetail",
                columns: table => new
                {
                    ContractDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contract__CCA7AF0219FDBE4A", x => x.ContractDetailID);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Owner__819385989B402EBE", x => x.OwnerID);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Unit = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ServiceStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Service__C51BB0EA10851A59", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    StaffStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AvatarLink = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Staff__96D4AAF714D24248", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentType",
                columns: table => new
                {
                    ApartmentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Apartmen__8BA7C03291493104", x => x.ApartmentTypeID);
                    table.ForeignKey(
                        name: "FK__Apartment__Build__3D5E1FD2",
                        column: x => x.BuildingID,
                        principalTable: "Building",
                        principalColumn: "BuildingID");
                });

            migrationBuilder.CreateTable(
                name: "Tennant",
                columns: table => new
                {
                    TennantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractDetailID = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tennant__901A3DC786213888", x => x.TennantID);
                    table.ForeignKey(
                        name: "FK__Tennant__Contrac__46E78A0C",
                        column: x => x.ContractDetailID,
                        principalTable: "ContractDetail",
                        principalColumn: "ContractDetailID");
                });

            migrationBuilder.CreateTable(
                name: "StaffDetail",
                columns: table => new
                {
                    StaffDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffID = table.Column<int>(type: "int", nullable: true),
                    ServiceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StaffDet__56818E83A25BAA6D", x => x.StaffDetailID);
                    table.ForeignKey(
                        name: "FK__StaffDeta__Servi__5CD6CB2B",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID");
                    table.ForeignKey(
                        name: "FK__StaffDeta__Staff__5BE2A6F2",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID");
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    ApartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentTypeID = table.Column<int>(type: "int", nullable: true),
                    BuildingID = table.Column<int>(type: "int", nullable: true),
                    OwnerID = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "date", nullable: true),
                    ToDate = table.Column<DateTime>(type: "date", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    ApartmentStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Apartmen__CBDF5744EA80DBF6", x => x.ApartmentID);
                    table.ForeignKey(
                        name: "FK__Apartment__Apart__403A8C7D",
                        column: x => x.ApartmentTypeID,
                        principalTable: "ApartmentType",
                        principalColumn: "ApartmentTypeID");
                    table.ForeignKey(
                        name: "FK__Apartment__Build__412EB0B6",
                        column: x => x.BuildingID,
                        principalTable: "Building",
                        principalColumn: "BuildingID");
                    table.ForeignKey(
                        name: "FK__Apartment__Owner__4222D4EF",
                        column: x => x.OwnerID,
                        principalTable: "Owner",
                        principalColumn: "OwnerID");
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    PackageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentTypeID = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Package__322035EC4829DB79", x => x.PackageID);
                    table.ForeignKey(
                        name: "FK__Package__Apartme__534D60F1",
                        column: x => x.ApartmentTypeID,
                        principalTable: "ApartmentType",
                        principalColumn: "ApartmentTypeID");
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    AssetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetHistoryID = table.Column<int>(type: "int", nullable: true),
                    ApartmentID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ItemImage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Asset__4349237265B2A50D", x => x.AssetID);
                    table.ForeignKey(
                        name: "FK__Asset__Apartment__4E88ABD4",
                        column: x => x.ApartmentID,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentID");
                    table.ForeignKey(
                        name: "FK__Asset__AssetHist__4D94879B",
                        column: x => x.AssetHistoryID,
                        principalTable: "AssetHistory",
                        principalColumn: "AssetHistoryID");
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentID = table.Column<int>(type: "int", nullable: true),
                    ContractDetailID = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "date", nullable: true),
                    ToDate = table.Column<DateTime>(type: "date", nullable: true),
                    ContractImage = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ContractStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contract__C90D34095C8941B3", x => x.ContractID);
                    table.ForeignKey(
                        name: "FK__Contract__Apartm__49C3F6B7",
                        column: x => x.ApartmentID,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentID");
                    table.ForeignKey(
                        name: "FK__Contract__Contra__4AB81AF0",
                        column: x => x.ContractDetailID,
                        principalTable: "ContractDetail",
                        principalColumn: "ContractDetailID");
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BookDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsSequence = table.Column<bool>(type: "bit", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    ReqStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Request__33A8519A783C169C", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK__Request__Apartme__5FB337D6",
                        column: x => x.ApartmentID,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentID");
                });

            migrationBuilder.CreateTable(
                name: "PackageServiceDetail",
                columns: table => new
                {
                    PackSerDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceID = table.Column<int>(type: "int", nullable: true),
                    PackageID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PackageS__EF0F62DB4C1EC5A8", x => x.PackSerDetailID);
                    table.ForeignKey(
                        name: "FK__PackageSe__Packa__571DF1D5",
                        column: x => x.PackageID,
                        principalTable: "Package",
                        principalColumn: "PackageID");
                    table.ForeignKey(
                        name: "FK__PackageSe__Servi__5629CD9C",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID");
                });

            migrationBuilder.CreateTable(
                name: "AddOn",
                columns: table => new
                {
                    AddOnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<int>(type: "int", nullable: true),
                    ServiceID = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AddOn__682701A4C645370B", x => x.AddOnID);
                    table.ForeignKey(
                        name: "FK__AddOn__RequestID__6FE99F9F",
                        column: x => x.RequestID,
                        principalTable: "Request",
                        principalColumn: "RequestID");
                    table.ForeignKey(
                        name: "FK__AddOn__ServiceID__70DDC3D8",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bill__11F2FC4A06CE2AC5", x => x.BillID);
                    table.ForeignKey(
                        name: "FK__Bill__RequestID__656C112C",
                        column: x => x.RequestID,
                        principalTable: "Request",
                        principalColumn: "RequestID");
                });

            migrationBuilder.CreateTable(
                name: "RequestDetail",
                columns: table => new
                {
                    RequestDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<int>(type: "int", nullable: true),
                    PackageID = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "RequestLog",
                columns: table => new
                {
                    RequestLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<int>(type: "int", nullable: true),
                    MaintainItem = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RequestL__A2706F5E25904CEC", x => x.RequestLogID);
                    table.ForeignKey(
                        name: "FK__RequestLo__Reque__628FA481",
                        column: x => x.RequestID,
                        principalTable: "Request",
                        principalColumn: "RequestID");
                });

            migrationBuilder.CreateTable(
                name: "StaffLog",
                columns: table => new
                {
                    StaffLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffID = table.Column<int>(type: "int", nullable: true),
                    RequestLogID = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_AddOn_RequestID",
                table: "AddOn",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_AddOn_ServiceID",
                table: "AddOn",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_ApartmentTypeID",
                table: "Apartment",
                column: "ApartmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_BuildingID",
                table: "Apartment",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_OwnerID",
                table: "Apartment",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentType_BuildingID",
                table: "ApartmentType",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ApartmentID",
                table: "Asset",
                column: "ApartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetHistoryID",
                table: "Asset",
                column: "AssetHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_RequestID",
                table: "Bill",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ApartmentID",
                table: "Contract",
                column: "ApartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ContractDetailID",
                table: "Contract",
                column: "ContractDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Package_ApartmentTypeID",
                table: "Package",
                column: "ApartmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PackageServiceDetail_PackageID",
                table: "PackageServiceDetail",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "IX_PackageServiceDetail_ServiceID",
                table: "PackageServiceDetail",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ApartmentID",
                table: "Request",
                column: "ApartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetail_PackageID",
                table: "RequestDetail",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetail_RequestID",
                table: "RequestDetail",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestLog_RequestID",
                table: "RequestLog",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffDetail_ServiceID",
                table: "StaffDetail",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffDetail_StaffID",
                table: "StaffDetail",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLog_RequestLogID",
                table: "StaffLog",
                column: "RequestLogID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLog_StaffID",
                table: "StaffLog",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Tennant_ContractDetailID",
                table: "Tennant",
                column: "ContractDetailID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddOn");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "PackageServiceDetail");

            migrationBuilder.DropTable(
                name: "RequestDetail");

            migrationBuilder.DropTable(
                name: "StaffDetail");

            migrationBuilder.DropTable(
                name: "StaffLog");

            migrationBuilder.DropTable(
                name: "Tennant");

            migrationBuilder.DropTable(
                name: "AssetHistory");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "RequestLog");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "ContractDetail");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "ApartmentType");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
