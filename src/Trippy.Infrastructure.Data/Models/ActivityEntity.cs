namespace Trippy.Infrastructure.Data.Models;

public class ActivityEntity : EntityBase
{
    public string? Name { get; set; }

    public string? Description { get; set; }
    
    public string? Location { get; set; }

    public DateTime? StartDateTime { get; set; }

    public DateTime? FinishDateTime { get; set; }

    public int? TripId { get; set; }

    public virtual TripEntity? Trip { get; set; }
    
    public virtual ICollection<AttendanceEntity> Attendance { get; set; }
    
    public virtual ICollection<ParticipantEntity> Participants { get; set; }
}