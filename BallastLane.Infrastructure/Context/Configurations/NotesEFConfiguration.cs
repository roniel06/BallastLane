using BallastLane.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BallastLane.Infrastructure.Context.Configurations
{
    public class NotesEFConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(1000).IsRequired();
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
