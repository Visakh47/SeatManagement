using SeatManagementAPI.Models;
using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Views
{
    public class FacilityManagerView
    {
        IFacilityManager facilityManager;
       

        public FacilityManagerView(IFacilityManager facilityManager)
        {
            this.facilityManager = facilityManager;
        }
        public async Task<int> CreateFacilityView() {

            IEntityManager<City> cityManager = new EntityManager<City>("City");
            IEntityManager<Building> buildingManager = new EntityManager<Building>("buildings");
            CityManagerView cityManagerView = new CityManagerView(cityManager);
            BuildingManagerView buildingManagerView = new BuildingManagerView(buildingManager);

            Console.WriteLine("Onboarding Facility");
            Console.WriteLine("Enter Details:");


            Console.WriteLine("Which City Does The Facility Belong To?");

            var cityId = await cityManagerView.CreateOrAddExistingCityView();

            Console.WriteLine("Which Building Does The Facility Belong To?");

            var buildingId = await buildingManagerView.CreateOrAddExistingBuildingView();

            Console.Write("Which Floor hosts the Facility: ");
            var floorNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("What Is The Name Of The Facility: ");
            var facilityName = Console.ReadLine();

            Facility facility = new Facility
            {
                FacilityName = facilityName,
                FacilityFloor = floorNumber,
                BuildingId = buildingId,
                CityId = cityId,
            };

            return await facilityManager.OnBoardFacility(facility);
        }
        public async void AllFacilitiesView() {
            throw new NotImplementedException();
        }
    }
}
