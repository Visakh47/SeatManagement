using SeatManagementAPI.Models;
using SeatManagementConsole.Interfaces;

internal class CabinManagerView
{
    private IEntityManager<Cabin> cabinManager;

    public CabinManagerView(IEntityManager<Cabin> cabinManager)
    {
        this.cabinManager = cabinManager;
    }

    public async void AddBulkCabinsView(int facilityId)
    {
        Console.WriteLine("How many number of cabins does the facility have?");
        var totalCabins = Convert.ToInt32(Console.ReadLine());
        string extension = $"/addbatch?FacilityId={facilityId}&totalCabins={totalCabins}";
        cabinManager.AddMany(extension);
    }
}