using System;
using System.Collections.Generic;

namespace FlightApi.Models;

public partial class BFlight
{
    public int FlightId { get; set; }

    public string? Origin { get; set; }

    public string? Destination { get; set; }

    public DateOnly Departure { get; set; }

    public DateOnly Arrival { get; set; }

    public string? FlightName { get; set; }

    public int? Cost { get; set; }

    public int? SeatAvailable { get; set; }

    public virtual ICollection<BBookingDetail> BBookingDetails { get; set; } = new List<BBookingDetail>();
}
