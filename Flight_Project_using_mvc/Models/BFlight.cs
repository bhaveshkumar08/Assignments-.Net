using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightProject.Models;

public partial class BFlight
{
    public int FlightId { get; set; }

    [Display(Name = "From Where?")]
    [Required(ErrorMessage = "This is Required")]
    public string? Origin { get; set; }

    [Display(Name = "To Where?")]
    [Required(ErrorMessage = "This is Required")]
    public string? Destination { get; set; }

    [Display(Name = "Departure Date")]
    [Required(ErrorMessage = "This is Required")]
    public DateOnly Departure { get; set; }

    [Display(Name = "Arrival Date")]
    [Required(ErrorMessage = "This is Required")]
    public DateOnly Arrival { get; set; }

    [Display(Name = "Name of Airline")]
    [Required(ErrorMessage = "This is Required")]
    public string? FlightName { get; set; }

    [Display(Name = "Cost")]
    [Required(ErrorMessage = "This is Required")]
    public int? Cost { get; set; }

    [Display(Name = "Seats Available")]
    [Required(ErrorMessage = "This is Required")]
    public int? SeatAvailable { get; set; }

    public virtual ICollection<BBookingDetail> BBookingDetails { get; set; } = new List<BBookingDetail>();
}
