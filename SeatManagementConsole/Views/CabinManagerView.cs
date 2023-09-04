using SeatManagementAPI.Models;
using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Managers;

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

    public async Task AllocateCabinView()
    {
        IReportManager<CabinUnAllocatedView> cuaReportManager = new ReportManager<CabinUnAllocatedView>("Report/cabindeallocatedList");
        IReportManagerView unAllocatedReportManagerView = new UnAllocatedReportManagerView(null, cuaReportManager);
        IEntityManager<Employee> employeeManager = new EntityManager<Employee>("Employee");
        EmployeeManagerView employeeManagerView = new EmployeeManagerView(employeeManager);

     
        await employeeManagerView.ListUnAllocatedEmployeesView();

        Console.Write("Enter An Employee Id: ");
        var empId = Convert.ToInt32(Console.ReadLine());

   
        unAllocatedReportManagerView.DisplayCabin();

        Console.Write("Enter A Cabin Id: ");
        var entityId = Convert.ToInt32(Console.ReadLine());

        IAllocationManager<Cabin> CabinAllocater = new AllocationManager<Cabin>("Cabin");

        CabinAllocater.Allocate(entityId, empId);
    }

    public async Task DeAllocateCabinView()
    {
        IReportManager<CabinOverview> cuaReportManager = new ReportManager<CabinOverview>("Report/cabinallocatedList");
        IReportManagerView allocatedReportManagerView = new AllocatedReportManagerView(null, cuaReportManager);

        allocatedReportManagerView.DisplayCabin();

        Console.Write("Enter A Cabin Id: ");
        var entityId = Convert.ToInt32(Console.ReadLine());

        IAllocationManager<Cabin> CabinAllocater = new AllocationManager<Cabin>("Cabin");

        CabinAllocater.DeAllocate(entityId);
    }
}