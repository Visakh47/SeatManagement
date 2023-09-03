using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatManagementAPI.Migrations
{
    public partial class unallocatedviewDistinct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW UnAllocatedView AS
                                    SELECT DISTINCT C.CityAbbreviation, B.BuildingAbbreviation, F.FacilityFloor, F.FacilityName, S.SeatCode 
                                    FROM Facilities F    
                                    JOIN Cities C                                                    
                                    ON F.CityId = C.CityId                                                      
                                    JOIN Buildings B                                                     
                                    ON F.BuildingId = B.BuildingId                                                    
                                    JOIN Seats S                                                    
                                    ON F.FacilityId = S.FacilityId                                                     
                                    JOIN Employees E                                                     
                                    ON S.EmployeeId IS NULL;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW Overview;");
        }
    }
}
