using System;
using System.Collections.Generic;

namespace Zdybanka.Core;

public partial class UserEvent
{
    public Guid UserId { get; set; }

    public Guid EventId { get; set; }

    public DateTime JoinedAt { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
