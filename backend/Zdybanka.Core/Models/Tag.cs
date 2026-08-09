using System;
using System.Collections.Generic;

namespace Zdybanka.Core;

public partial class Tag
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
