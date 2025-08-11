using MemoryPack;

namespace LPR_Intercon.Shared.Models;

[MemoryPackable]
public partial class BaseEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

[MemoryPackable]
public partial class IHasTimestamps
{
    public long? CreatedAtTicks { get; set; }
    public long? UpdatedAtTicks { get; set; }
    [MemoryPackIgnore]
    public DateTimeOffset? CreatedAt => CreatedAtTicks.HasValue
        ? new DateTimeOffset(CreatedAtTicks.Value, TimeSpan.Zero)
        : null;

    [MemoryPackIgnore]
    public DateTimeOffset? UpdatedAt => UpdatedAtTicks.HasValue
        ? new DateTimeOffset(UpdatedAtTicks.Value, TimeSpan.Zero)
        : null;
}
