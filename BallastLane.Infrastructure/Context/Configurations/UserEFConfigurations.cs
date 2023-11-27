using BallastLane.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BallastLane.Infrastructure.Context.Configurations
{
    internal class UserEFConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x=> x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x=> x.DateOfBirth).IsRequired();
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
