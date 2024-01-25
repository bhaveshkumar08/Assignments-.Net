using System;
using System.Collections.Generic;

namespace FlightProject.Models;

public partial class FullBookingDetails
{
     public int BookingId { get; set; }

    public int FlightId { get; set; }

    public int? CustomerId { get; set; }

    public int? BookedSeats { get; set; }
 
    public int? TotalCost { get; set; }

    public string? FlightType { get; set; }

    public string? Origin { get; set; }

    public string? Destination { get; set; }

    public DateOnly Departure { get; set; }

    public DateOnly Arrival { get; set; }

    public string? FlightName { get; set; }
}
