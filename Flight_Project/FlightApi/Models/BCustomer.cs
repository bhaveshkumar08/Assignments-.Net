using System;
using System.Collections.Generic;

namespace FlightApi.Models;

public partial class BCustomer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public int? CustomerAge { get; set; }

    public string? CustomerAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CustomerEmailId { get; set; }

    public string? CustomerUsername { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<BBookingDetail> BBookingDetails { get; set; } = new List<BBookingDetail>();
}
