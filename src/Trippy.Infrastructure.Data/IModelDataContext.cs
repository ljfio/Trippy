using Microsoft.EntityFrameworkCore;
using Trippy.Infrastructure.Data.Models;

namespace Trippy.Infrastructure.Data;

public interface IModelDataContext
{
    DbSet<TripEntity> Trips { get; set; }
    
    DbSet<ActivityEntity> Activities { get; set; }
    
    DbSet<ParticipantEntity> Participants { get; set; }
}