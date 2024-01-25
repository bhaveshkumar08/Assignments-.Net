using System.Data.Common;
using FlightApi.Models;
using FlightProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstapi.Repository;

class BookingRepo : IBookingRepo<BBookingDetail>
{
    private readonly Ace52024Context _db;

    public BookingRepo(){

    }

    public BookingRepo(Ace52024Context db){
        _db = db;
    }

    public async Task BookingConfirm(FullBookingDetails fd)
    {
        BBookingDetail nb = new BBookingDetail();
            nb.CustomerId = fd.CustomerId;
            nb.BookedSeats = fd.BookedSeats;
            nb.FlightId = fd.FlightId;
            nb.TotalCost = fd.TotalCost;
            BFlight fchange = _db.BFlights.Where(x=>x.FlightId == fd.FlightId).FirstOrDefault();  
            fchange.SeatAvailable -= fd.BookedSeats;
            _db.BFlights.Update(fchange);

            _db.BBookingDetails.Add(nb);
        
            await _db.SaveChangesAsync();
    }

    public async Task<ActionResult<FullBookingDetails>> BookingDetails(int id, int seats, int cid)
    {
        FullBookingDetails newBooking = new FullBookingDetails();
            BFlight f = _db.BFlights.Where(x=>x.FlightId == id).SingleOrDefault();
            newBooking.FlightId = id;
            newBooking.Arrival = f.Arrival;
            newBooking.TotalCost = seats*f.Cost;
            newBooking.BookedSeats = seats;
            newBooking.Departure = f.Departure;
            newBooking.Origin = f.Origin;
            newBooking.Destination = f.Destination;
            newBooking.FlightName = f.FlightName;
            newBooking.CustomerId = cid;
            
            return newBooking;
    }

    public async Task<ActionResult<IEnumerable<FullBookingDetails>>> BookingHistory(int id)
    {
        List<FullBookingDetails> newBooking = new List<FullBookingDetails>();
            var allbooking = _db.BBookingDetails.Where(x=>x.CustomerId == id).Include(x=>x.Flight);

            foreach (var item in allbooking)
            {
                FullBookingDetails temp = new FullBookingDetails();

                temp.CustomerId = id;
                temp.FlightId = item.FlightId;
                temp.BookingId = item.BookingId;
                temp.BookedSeats = item.BookedSeats;
                temp.TotalCost = item.TotalCost;
                temp.Arrival = item.Flight.Arrival;
                temp.Departure = item.Flight.Departure;
                temp.Origin = item.Flight.Origin;
                temp.Destination = item.Flight.Destination;
                temp.FlightName = item.Flight.FlightName;
                newBooking.Add(temp);
            }
            return newBooking;
    }
}
