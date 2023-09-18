namespace SeatManagementAPI.Custom_Exceptions
{
    public class FacilityNotFoundException: Exception
    {
        public FacilityNotFoundException() { }
        public FacilityNotFoundException(int id): base(String.Format($"Facility {id} Not Found!")) { 
        }
    }
}
