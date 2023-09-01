using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatManagementAPI.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allocations");

            migrationBuilder.DropTable(
                name: "FacilityAssets");

            migrationBuilder.DropTable(
                name: "FacilityDetails");

            migrationBuilder.DropTable(
                name: "SeatTypes");

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "Facilities",
                newName: "FacilityFloor");

            migrationBuilder.CreateTable(
                name: "Cabin",
                columns: table => new
                {
                    CabinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    CabinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabin", x => x.CabinId);
                    table.ForeignKey(
                        name: "FK_Cabin_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cabin_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRooms",
                columns: table => new
                {
                    MeetingRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    MeetingRoomCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRooms", x => x.MeetingRoomId);
                    table.ForeignKey(
                        name: "FK_MeetingRooms_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    SeatCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seats_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRoomAssets",
                columns: table => new
                {
                    MeetingRoomAssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingRoomId = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    NoOfItems = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRoomAssets", x => x.MeetingRoomAssetId);
                    table.ForeignKey(
                        name: "FK_MeetingRoomAssets_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingRoomAssets_MeetingRooms_MeetingRoomId",
                        column: x => x.MeetingRoomId,
                        principalTable: "MeetingRooms",
                        principalColumn: "MeetingRoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabin_EmployeeId",
                table: "Cabin",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cabin_FacilityId",
                table: "Cabin",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRoomAssets_AssetId",
                table: "MeetingRoomAssets",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRoomAssets_MeetingRoomId",
                table: "MeetingRoomAssets",
                column: "MeetingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRooms_FacilityId",
                table: "MeetingRooms",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_EmployeeId",
                table: "Seats",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_FacilityId",
                table: "Seats",
                column: "FacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cabin");

            migrationBuilder.DropTable(
                name: "MeetingRoomAssets");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "MeetingRooms");

            migrationBuilder.RenameColumn(
                name: "FacilityFloor",
                table: "Facilities",
                newName: "Floor");

            migrationBuilder.CreateTable(
                name: "FacilityAssets",
                columns: table => new
                {
                    FacilityAssetsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityAssets", x => x.FacilityAssetsId);
                    table.ForeignKey(
                        name: "FK_FacilityAssets_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityAssets_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatTypes",
                columns: table => new
                {
                    SeatTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTypes", x => x.SeatTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FacilityDetails",
                columns: table => new
                {
                    FacilityDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    SeatTypesSeatTypeId = table.Column<int>(type: "int", nullable: false),
                    SeatTotal = table.Column<int>(type: "int", nullable: false),
                    SeatTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityDetails", x => x.FacilityDetailsId);
                    table.ForeignKey(
                        name: "FK_FacilityDetails_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityDetails_SeatTypes_SeatTypesSeatTypeId",
                        column: x => x.SeatTypesSeatTypeId,
                        principalTable: "SeatTypes",
                        principalColumn: "SeatTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allocations",
                columns: table => new
                {
                    AllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FacilityDetailsId = table.Column<int>(type: "int", nullable: false),
                    SeatCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allocations", x => x.AllocationId);
                    table.ForeignKey(
                        name: "FK_Allocations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allocations_FacilityDetails_FacilityDetailsId",
                        column: x => x.FacilityDetailsId,
                        principalTable: "FacilityDetails",
                        principalColumn: "FacilityDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allocations_EmployeeId",
                table: "Allocations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocations_FacilityDetailsId",
                table: "Allocations",
                column: "FacilityDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityAssets_AssetId",
                table: "FacilityAssets",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityAssets_FacilityId",
                table: "FacilityAssets",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityDetails_FacilityId",
                table: "FacilityDetails",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityDetails_SeatTypesSeatTypeId",
                table: "FacilityDetails",
                column: "SeatTypesSeatTypeId");
        }
    }
}
