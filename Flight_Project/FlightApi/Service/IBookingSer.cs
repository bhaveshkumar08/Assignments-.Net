using FlightProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstapi.Service{
public interface IBookingSer<BBookingDetail>{
    Task<ActionResult<FullBookingDetails>> BookingDetails(int id, int seats, int cid);
    Task BookingConfirm(FullBookingDetails fd);
    Task<ActionResult<IEnumerable<FullBookingDetails>>> BookingHistory(int id);
    }
}
