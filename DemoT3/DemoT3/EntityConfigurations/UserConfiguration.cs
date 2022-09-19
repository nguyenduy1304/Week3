using DemoT3.Domains;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DemoT3.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
               .HasColumnType("varchar")
               .HasMaxLength(50);
            builder.Property(p => p.Username)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.Property(p => p.Password)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200);


            builder.HasOne(d => d.UserDetail)
                .WithOne(ad => ad.User).HasForeignKey<UserDetail>(c => c.IdUser);
        }
    }
}
