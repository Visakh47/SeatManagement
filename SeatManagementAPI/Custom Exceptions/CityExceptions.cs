namespace SeatManagementAPI.Custom_Exceptions
{
    public class CityNotFoundException : Exception
    {
        public CityNotFoundException() { }
        public CityNotFoundException(int id) : base(String.Format($"City {id} Not Found!"))
        {
        }
    }
}
