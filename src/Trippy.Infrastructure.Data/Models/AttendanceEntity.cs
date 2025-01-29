namespace Trippy.Infrastructure.Data.Models;

public class AttendanceEntity : EntityBase
{
    public int? ActivityId { get; set; }
    
    public int? ParticipantId { get; set; }

    public string? Note { get; set; }

    public virtual ActivityEntity? Activity { get; set; }

    public virtual ParticipantEntity? Participant { get; set; }
}