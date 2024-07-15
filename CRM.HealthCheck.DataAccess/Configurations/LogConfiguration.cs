using CRM.HealthCheck.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.HealthCheck.Core.Configurations
{
    internal class LogConfiguration : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Message);

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.Time)
                .IsRequired();

            builder.Property(b => b.Status)
                .IsRequired();
        }
    }
}
