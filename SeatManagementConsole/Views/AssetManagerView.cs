using SeatManagementAPI.Models;
using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Managers;

internal class AssetManagerView
{
    private readonly IEntityManager<Asset> assetManager;

    public AssetManagerView(IEntityManager<Asset> assetManager)
    {
        this.assetManager = assetManager;
    }
    public async Task<int> CreateOrAddExistingAssetView()
    {
        IEntityManager<Asset> assetManager = new EntityManager<Asset>("Asset");
        var assets = await assetManager.GetAll();
        int opA,assetId;

        Console.WriteLine("Adding Assets Menu:");
        Console.WriteLine("1.Add existing Asset\n2.Add new Asset\n3.No More Assets");
        Console.Write("Enter your option:");
        opA = Convert.ToInt32(Console.ReadLine());
        assetId = 0; //Change all if-else to switch.
        if (opA == 1)
        {
            foreach (var asset in assets)
            {
                Console.WriteLine($"{asset.AssetId}. {asset.AssetName}");
            }
            Console.Write("Enter the asset Id of the asset you want to add: ");
            assetId = Convert.ToInt32(Console.ReadLine());

        }
        else if (opA == 2)
        {
            Console.Write("Enter the name of asset: ");
            var assetName = Console.ReadLine();

            var asset = new Asset { AssetName = assetName };
            assetId = await assetManager.Add(asset);
        }
        else if (opA == 3)
        {
            return 0;
        }
            
     
        return assetId;
    }
}