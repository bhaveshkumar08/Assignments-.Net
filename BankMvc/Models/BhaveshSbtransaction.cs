using System;
using System.Collections.Generic;

namespace firstMVCPoject.Models;

public partial class BhaveshSbtransaction
{
    public int TransactionId { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public decimal? Amount { get; set; }

    public string? TransactionType { get; set; }

    public int? AccountNumber { get; set; }

    public virtual BhaveshSbaccount? AccountNumberNavigation { get; set; }
}
