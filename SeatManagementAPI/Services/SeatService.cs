using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;
using SeatManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

public class SeatService : ISeatService
{
    private readonly IRepository<Seat> _seatRepository;
    private readonly IRepository<Employee> _employeeRepository;

    public SeatService(IRepository<Seat> seatRepository, IRepository<Employee> employeeRepository)
    {
        _seatRepository = seatRepository;
        _employeeRepository = employeeRepository;
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
        if (seat.Employee == null) { 
            Employee e = _employeeRepository.GetById(employeeId);
            seat.Employee = e;
            seat.Employee.isAllocated = true;
        }
        _seatRepository.Update(seat);
    }

    public void SeatDeallocate(int seatId)
    {
        var seat = _seatRepository.GetById(seatId);
        
        if (seat.Employee != null)
        {
            Employee e = _employeeRepository.GetById(seat.Employee.EmployeeId);
            seat.Employee = e;
            seat.Employee.isAllocated = false;
        }
        seat.Employee = null;
        seat.EmployeeId = null;
        _seatRepository.Update(seat);
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
