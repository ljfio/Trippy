using Microsoft.EntityFrameworkCore;
using Trippy.Infrastructure.Data.Models;

namespace Trippy.Infrastructure.Data;

public class ModelDataContext : DbContext, IModelDataContext
{
    public virtual DbSet<TripEntity> Trips { get; set; }

    public virtual DbSet<ActivityEntity> Activities { get; set; }

    public virtual DbSet<ParticipantEntity> Participants { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);

        // Entity Base
        model.Entity<EntityBase>()
            .HasKey(e => e.Id);
        
        model.Entity<EntityBase>()
            .Property(e => e.RowVersion)
            .IsRowVersion();
        
        // Trip
        model.Entity<TripEntity>()
            .Property(e => e.Name)
            .HasMaxLength(200);
        
        model.Entity<TripEntity>()
            .Property(e => e.Description)
            .HasMaxLength(65535);
        
        // Activity
        model.Entity<ActivityEntity>()
            .Property(e => e.Name)
            .HasMaxLength(200);
        
        model.Entity<ActivityEntity>()
            .Property(e => e.Description)
            .HasMaxLength(65535);
        
        model.Entity<ActivityEntity>()
            .Property(e => e.Location)
            .HasMaxLength(65535);
        
        // Participant
        model.Entity<ParticipantEntity>()
            .Property(e => e.Name)
            .HasMaxLength(200);
        
        // Attendance
        model.Entity<AttendanceEntity>()
            .Property(e => e.Note)
            .HasMaxLength(65535);
        
        // Relations
        model.Entity<TripEntity>()
            .HasMany<ActivityEntity>(e => e.Activities)
            .WithOne(e => e.Trip)
            .HasForeignKey(e => e.TripId);

        model.Entity<ActivityEntity>()
            .HasMany<ParticipantEntity>(e => e.Participants)
            .WithMany(e => e.Activities)
            .UsingEntity<AttendanceEntity>(
                l => l.HasOne<ParticipantEntity>(e => e.Participant)
                    .WithMany(e => e.Attendance)
                    .HasForeignKey(e => e.ParticipantId),
                r => r.HasOne<ActivityEntity>(e => e.Activity)
                    .WithMany(e => e.Attendance)
                    .HasForeignKey(e => e.ActivityId));
    }
}