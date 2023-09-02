using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;
using SeatManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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
            EmployeeId = null
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

    public void SeatAllocate(int seatId, int employeeId)
    {
        var seat = _seatRepository.GetById(seatId);
        seat.EmployeeId = employeeId;
    }

    public void SeatDeallocate(int seatId)
    {
        var seat = _seatRepository.GetById(seatId);
        seat.EmployeeId = null;
        seat.Employee = null;
    }

    public void AddManySeats(int totalSeats, int facilityId) {
        List<Seat> emptySeats = new List<Seat>();
        for (int i = 1; i <= totalSeats; i++)
        {
            
            Seat emptySeat = new Seat
            {
                FacilityId = facilityId,
                SeatCode = $"S{i:D3}"
            };
            emptySeats.Add(emptySeat);
        }

        _seatRepository.AddMany(emptySeats);
    }

}
