using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentType",
                columns: table => new
                {
                    ApartmentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentTypeName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ApartmentTypeDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ApartmentTypeStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentType", x => x.ApartmentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Asset_History",
                columns: table => new
                {
                    AssetHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AssetHisQuantity = table.Column<int>(type: "int", nullable: true),
                    AssetHisItemImage = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AssetHisStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset_History", x => x.AssetHistoryID);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    BuildingAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    BuildingStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.BuildingID);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    OwnerEmail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    OwnerPassword = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    OwnerPhone = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    OwnerAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    OwnerStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerID);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    ServiceName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ServicePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Unit = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ServiceStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    StaffStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "Tennant",
                columns: table => new
                {
                    TennantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TennantName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TennantEmail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TennantPassword = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TennantStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TennantPhone = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TennantAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tennant", x => x.TennantID);
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
                    ApartmentStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.ApartmentID);
                    table.ForeignKey(
                        name: "FK__Apartment__Apart__2A4B4B5E",
                        column: x => x.ApartmentTypeID,
                        principalTable: "ApartmentType",
                        principalColumn: "ApartmentTypeID");
                    table.ForeignKey(
                        name: "FK__Apartment__Build__2B3F6F97",
                        column: x => x.BuildingID,
                        principalTable: "Building",
                        principalColumn: "BuildingID");
                    table.ForeignKey(
                        name: "FK__Apartment__Owner__2C3393D0",
                        column: x => x.OwnerID,
                        principalTable: "Owner",
                        principalColumn: "OwnerID");
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    AssetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetHistoryID = table.Column<int>(type: "int", nullable: true),
                    ApartmentID = table.Column<int>(type: "int", nullable: true),
                    AssetName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    AssetDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AssetItemImage = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AssetStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.AssetID);
                    table.ForeignKey(
                        name: "FK__Asset__Apartment__37A5467C",
                        column: x => x.ApartmentID,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentID");
                    table.ForeignKey(
                        name: "FK__Asset__AssetHist__36B12243",
                        column: x => x.AssetHistoryID,
                        principalTable: "Asset_History",
                        principalColumn: "AssetHistoryID");
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentID = table.Column<int>(type: "int", nullable: true),
                    TennantID = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "date", nullable: true),
                    ToDate = table.Column<DateTime>(type: "date", nullable: true),
                    ContractImage = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ContractStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractID);
                    table.ForeignKey(
                        name: "FK__Contract__Apartm__30F848ED",
                        column: x => x.ApartmentID,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentID");
                    table.ForeignKey(
                        name: "FK__Contract__Tennan__31EC6D26",
                        column: x => x.TennantID,
                        principalTable: "Tennant",
                        principalColumn: "TennantID");
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentID = table.Column<int>(type: "int", nullable: true),
                    ReqDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    BookDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsSequence = table.Column<bool>(type: "bit", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    ReqStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK__Requests__Apartm__3E52440B",
                        column: x => x.ApartmentID,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentID");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    BillStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillID);
                    table.ForeignKey(
                        name: "FK__Bill__RequestID__440B1D61",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID");
                });

            migrationBuilder.CreateTable(
                name: "Request_Log",
                columns: table => new
                {
                    RequestLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<int>(type: "int", nullable: true),
                    MaintainItem = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ReqLogDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    RegLogStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request_Log", x => x.RequestLogID);
                    table.ForeignKey(
                        name: "FK__Request_L__Reque__412EB0B6",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID");
                });

            migrationBuilder.CreateTable(
                name: "Service_Detail",
                columns: table => new
                {
                    ServiceDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceID = table.Column<int>(type: "int", nullable: true),
                    RequestID = table.Column<int>(type: "int", nullable: true),
                    SerDeDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SerDePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    ItemBillImage = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SerDeStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Detail", x => x.ServiceDetailID);
                    table.ForeignKey(
                        name: "FK__Service_D__Reque__47DBAE45",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID");
                    table.ForeignKey(
                        name: "FK__Service_D__Servi__46E78A0C",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID");
                });

            migrationBuilder.CreateTable(
                name: "Staff_Log",
                columns: table => new
                {
                    StaffLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffID = table.Column<int>(type: "int", nullable: true),
                    RequestLogID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff_Log", x => x.StaffLogID);
                    table.ForeignKey(
                        name: "FK__Staff_Log__Reque__4BAC3F29",
                        column: x => x.RequestLogID,
                        principalTable: "Request_Log",
                        principalColumn: "RequestLogID");
                    table.ForeignKey(
                        name: "FK__Staff_Log__Staff__4AB81AF0",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID");
                });

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
                name: "IX_Contract_TennantID",
                table: "Contract",
                column: "TennantID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Log_RequestID",
                table: "Request_Log",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ApartmentID",
                table: "Requests",
                column: "ApartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Detail_RequestID",
                table: "Service_Detail",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Detail_ServiceID",
                table: "Service_Detail",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Log_RequestLogID",
                table: "Staff_Log",
                column: "RequestLogID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Log_StaffID",
                table: "Staff_Log",
                column: "StaffID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Service_Detail");

            migrationBuilder.DropTable(
                name: "Staff_Log");

            migrationBuilder.DropTable(
                name: "Asset_History");

            migrationBuilder.DropTable(
                name: "Tennant");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Request_Log");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "ApartmentType");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
