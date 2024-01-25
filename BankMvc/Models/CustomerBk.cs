using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstMVCPoject.Models;

public partial class CustomerBk
{
    public int Cid { get; set; }

    [Display(Name ="Customer Name")]
    [Required(ErrorMessage ="Customer Name is Mandatory")]
    public string? Cname { get; set; }

    [Display(Name ="Salary")]
    [Range(minimum:50000,maximum:100000,ErrorMessage ="Salary should be between 5k and 1L")]
    public int? Csalary { get; set; }

    [DataType(DataType.Date)]
    [Display(Name ="Date of Joining")]
    public DateOnly? Doj { get; set; }

    [Display(Name ="Phone Number")]
    [StringLength(maximumLength:10,MinimumLength =10,ErrorMessage ="Ph no should be exact 10 digits")]
    public string? Phn { get; set; }

    [Display(Name ="Email Address")]

    [Required(ErrorMessage ="Please enter an email")]
    [DataType(DataType.EmailAddress,ErrorMessage ="Please enter a valid email address")]
    public string? Cemail { get; set; }

    [Display(Name ="Password")]
    [Required(ErrorMessage ="Password is required")]
    public string? Password { get; set; }

    [NotMapped]
    [Compare("Password",ErrorMessage ="Passwords do not match")]
    [Display(Name ="Confirm Password")]

    public string? ConfirmPassword{get;set;}
}
