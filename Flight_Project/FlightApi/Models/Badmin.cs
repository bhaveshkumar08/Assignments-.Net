using System;
using System.Collections.Generic;

namespace FlightApi.Models;

public partial class Badmin
{
    public int AdminId { get; set; }

    public string? AdminName { get; set; }

    public string? Password { get; set; }
}
