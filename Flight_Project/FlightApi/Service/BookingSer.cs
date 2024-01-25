using System.Data.Common;
using firstapi.Repository;
using FlightApi.Models;
using FlightProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstapi.Service;

class BookingSer : IBookingSer<BBookingDetail>
{
    private readonly IBookingRepo<BBookingDetail> _dbRepo;

    public BookingSer(){

    }

    public BookingSer(IBookingRepo<BBookingDetail> dbRepo){
        _dbRepo = dbRepo;
    }

    public async Task BookingConfirm(FullBookingDetails fd)
    {
        await _dbRepo.BookingConfirm(fd);
    }

    public async Task<ActionResult<FullBookingDetails>> BookingDetails(int id, int seats, int cid)
    {            
        return await _dbRepo.BookingDetails(id, seats, cid);
    }

    public async Task<ActionResult<IEnumerable<FullBookingDetails>>> BookingHistory(int id)
    {
        return await _dbRepo.BookingHistory(id);
    }
}
