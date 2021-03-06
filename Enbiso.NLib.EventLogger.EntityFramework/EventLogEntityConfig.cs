﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enbiso.NLib.EventLogger.EntityFramework
{
    /// <inheritdoc />
    /// <summary>
    /// Event log entity configurations
    /// </summary>
    public class EventLogEntityConfig : IEntityTypeConfiguration<EventLog>
    {
        public void Configure(EntityTypeBuilder<EventLog> builder)
        {
            builder.Ignore(e => e.State);

            builder.HasKey(e => e.EventId);

            builder.Property(e => e.EventId)
                .IsRequired();

            builder.Property(e => e.Content)
                .IsRequired();

            builder.Property(e => e.CreationTime)
                .IsRequired();

            builder.Property("_state")
                .IsRequired().HasColumnName("State");

            builder.Property(e => e.TimesSent)
                .IsRequired();

            builder.Property(e => e.EventTypeName)
                .IsRequired();
        }
    }

    /// <summary>
    /// Model builder extensions
    /// </summary>
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ApplyEventLoggerConfiguration(this ModelBuilder builder)
        {
            return builder.ApplyConfiguration(new EventLogEntityConfig());
        }
    }

}
