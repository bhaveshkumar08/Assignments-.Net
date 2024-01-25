using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightApi.Models;

public partial class SearchCapture
{
    [Display(Name ="From Where?")]
    public string? origin {get; set; }

    [Display(Name ="To Where?")]
    public string? destination {get; set; }

    [Display(Name ="Depature Date")]
    public DateOnly departure {get; set; }

    [Display(Name ="Traveler")]
    [Range(minimum:1,maximum:5,ErrorMessage ="Can book only between 1 to 5 seats only")]
    public int seats{get; set; }
}

