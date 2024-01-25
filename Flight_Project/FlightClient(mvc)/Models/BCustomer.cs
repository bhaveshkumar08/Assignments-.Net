using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightProject.Models;

public partial class BCustomer
{
    public int CustomerId { get; set; }

    [Display(Name ="Name")]
    [Required(ErrorMessage ="Customer Name is Mandatory")]
    public string? CustomerName { get; set; }

    [Display(Name ="Age")]
    [Range(minimum:18,maximum:90,ErrorMessage ="Age should be between 18 and 90")]
    public int? CustomerAge { get; set; }

    [Display(Name ="Address")]

    public string? CustomerAddress { get; set; }

    [Display(Name ="Phone Number")]
    [StringLength(maximumLength:10,MinimumLength =10,ErrorMessage ="Ph no should be exact 10 digits")]
    public string? PhoneNumber { get; set; }

    [Display(Name ="Email Address")]
    [Required(ErrorMessage ="Please enter an email")]
    [DataType(DataType.EmailAddress,ErrorMessage ="Please enter a valid email address")]
    public string? CustomerEmailId { get; set; }

    [Display(Name ="User Name")]
    [Required(ErrorMessage ="Please enter User name")]
    [RegularExpression(@"^(?=.*[0-9_])[a-zA-Z0-9_]*$", ErrorMessage ="Atleast one digit or underscore is required")]
    public string? CustomerUsername { get; set; }

    [Display(Name ="Password")]
    [Required(ErrorMessage ="Password is required")]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[^a-zA-Z0-9])[a-zA-Z0-9_@$#&!]*$", ErrorMessage ="Atleast one digit or special character is required")]

    public string? Password { get; set; }


    [NotMapped]
    [Compare("Password",ErrorMessage ="Passwords do not match")]
    [Display(Name ="Confirm Password")]
    public string? ConfirmPassword { get; set; } 
}
