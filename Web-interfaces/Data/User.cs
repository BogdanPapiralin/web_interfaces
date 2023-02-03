using System;
using System.Collections.Generic;

namespace Web_interfaces.Data;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Rights { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
