using System;
using System.Collections.Generic;

namespace Web_interfaces.Data;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
