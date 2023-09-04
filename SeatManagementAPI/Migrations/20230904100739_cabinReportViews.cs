using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatManagementAPI.Migrations
{
    public partial class cabinReportViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW CabinUnAllocatedView AS
                                    SELECT DISTINCT C.CityAbbreviation, B.BuildingAbbreviation, F.FacilityFloor, F.FacilityName, Ca.CabinCode , Ca.CabinId
                                    FROM Facilities F    
                                    JOIN Cities C                                                    
                                    ON F.CityId = C.CityId                                                      
                                    JOIN Buildings B                                                     
                                    ON F.BuildingId = B.BuildingId                                                    
                                    JOIN Cabin Ca                                                   
                                    ON F.FacilityId = Ca.FacilityId                                                     
                                    JOIN Employees E                                                     
                                    ON Ca.EmployeeId IS NULL;");
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW CabinOverview AS
                                    SELECT C.CityAbbreviation, B.BuildingAbbreviation, F.FacilityFloor, F.FacilityName, Ca.CabinCode , Ca.CabinId, E.EmployeeName 
                                    FROM Facilities F    
                                    JOIN Cities C                                                    
                                    ON F.CityId = C.CityId                                                      
                                    JOIN Buildings B                                                     
                                    ON F.BuildingId = B.BuildingId                                                    
                                    JOIN Cabin Ca                                                   
                                    ON F.FacilityId = Ca.FacilityId                                                     
                                    JOIN Employees E                                                     
                                    ON Ca.EmployeeId = E.EmployeeId;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW CabinUnAllocatedView;");
            migrationBuilder.Sql(@"DROP VIEW CabinOverview;");
        }
    }
}
