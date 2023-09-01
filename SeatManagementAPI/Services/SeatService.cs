using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;
using SeatManagementAPI.Interfaces;

public class SeatService : ISeatService
{
    private readonly IRepository<Seat> _seatRepository;

    public SeatService(IRepository<Seat> seatRepository)
    {
        _seatRepository = seatRepository;
    }


    public Seat[] GetAllSeats()
    {
        return _seatRepository.GetAll();
    }


    public void AddSeat(SeatDTO seat)
    {
        _seatRepository.Add(new Seat
        {
            FacilityId = seat.FacilityId,
            SeatCode = seat.SeatCode,
            EmployeeId = seat.EmployeeId
        });
    }


    public Seat GetSeatById(int id)
    {
        return _seatRepository.GetById(id);
    }


    public void EditSeat(Seat seat)
    {
        var originalSeat = _seatRepository.GetById(seat.SeatId);
        if (originalSeat == null)
        {
            throw new Exception("Not Found Seat");
        }

        originalSeat.FacilityId = seat.FacilityId;
        originalSeat.SeatCode = seat.SeatCode;
        originalSeat.EmployeeId = seat.EmployeeId;

        _seatRepository.Update(originalSeat);
    }


    public void DeleteSeatById(int id)
    {
        _seatRepository.DeleteById(id);
    }
}
