using System;
using System.Collections.Generic;

namespace Web_interfaces.Data;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Language { get; set; } = null!;

    public string Types { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int Price { get; set; }

    public int Stock { get; set; }

    public byte[]? Image { get; set; }

    public int Pages { get; set; }

    public int? Years { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
