using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;

public interface ISeatService
{
    Seat[] GetAllSeats();
    void AddSeat(SeatDTO seat);
    Seat GetSeatById(int id);
    void EditSeat(Seat seat);
    void DeleteSeatById(int id);
}
