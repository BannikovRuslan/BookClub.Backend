using BookClub.Domains;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookClub.Persistence.EntityTypeConfiguration
{
    public class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
    {
        public void Configure(EntityTypeBuilder<Speaker> builder)
        {
            builder.HasKey(speaker => speaker.Id);
            builder.HasIndex(speaker => speaker.Id).IsUnique();
            builder.Property(speaker => speaker.FirstName).HasMaxLength(255).IsRequired();
            builder.Property(speaker => speaker.LastName).HasMaxLength(255).IsRequired();
        }
    }
}
