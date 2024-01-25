﻿using System;
using System.Collections.Generic;

namespace FlightApi.Models;

public partial class BBookingDetail
{
    public int BookingId { get; set; }

    public int FlightId { get; set; }

    public int? CustomerId { get; set; }

    public int? BookedSeats { get; set; }

    public int? TotalCost { get; set; }

    public string? FlightType { get; set; }

    public virtual BCustomer? Customer { get; set; }

    public virtual BFlight Flight { get; set; } = null!;
}