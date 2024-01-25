using FlightProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstapi.Repository{
public interface IBookingRepo<BBookingDetail>{
    Task<ActionResult<FullBookingDetails>> BookingDetails(int id, int seats, int cid);
    Task BookingConfirm(FullBookingDetails fd);
    Task<ActionResult<IEnumerable<FullBookingDetails>>> BookingHistory(int id);
    }
}
