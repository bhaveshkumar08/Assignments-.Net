using System;
using System.Collections.Generic;

namespace firstMVCPoject.Models;

public partial class BhaveshSbaccount
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public decimal? CurrentBalance { get; set; }

    public virtual ICollection<BhaveshSbtransaction> BhaveshSbtransactions { get; set; } = new List<BhaveshSbtransaction>();
}
