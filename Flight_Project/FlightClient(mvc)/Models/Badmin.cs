using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightProject.Models;

public partial class Badmin
{
    public int AdminId { get; set; }

    [Display(Name = "Admin UserName")]
    [Required(ErrorMessage ="UserName is required")]
    public string? AdminName { get; set; }

    [Display(Name ="Password")]
    [Required(ErrorMessage ="Password is required")]
    public string? Password { get; set; }
}
