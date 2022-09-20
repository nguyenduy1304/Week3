using DemoT3.Domains;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DemoT3.EntityConfigurations
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
            builder.Property(p => p.PhoneNumber)
                 .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(15);
            builder.Property(p => p.Address)
                .IsRequired()
               .HasColumnType("nvarchar")
               .HasMaxLength(255);
            builder.Property(p => p.IdUser)
                .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(50);
        }
    }
}
