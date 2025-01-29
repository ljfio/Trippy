namespace Trippy.Infrastructure.Data.Models;

public class ParticipantEntity : EntityBase
{
    public string? Name { get; set; }
    
    public virtual ICollection<AttendanceEntity> Attendance { get; set; }
    
    public virtual ICollection<ActivityEntity> Activities { get; set; }
}