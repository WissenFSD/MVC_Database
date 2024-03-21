using System;
using System.Collections.Generic;

namespace MVC_Database;

public partial class Authentication
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Autorization> Autorizations { get; set; } = new List<Autorization>();
}
