namespace Trippy.Infrastructure.Data.Models;

public class TripEntity : EntityBase
{
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime? StartDateTime { get; set; }
    
    public DateTime? FinishDateTime { get; set; }

    public virtual ICollection<ActivityEntity> Activities { get; set; }
}