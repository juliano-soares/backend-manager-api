using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .UseIdentityColumn()
                   .HasColumnType("BIGINT");

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(80)
                   .HasColumnName("name")
                   .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Username)
                  .IsRequired()
                  .HasColumnName("username")
                  .HasMaxLength(30)
                  .HasColumnType("VARCHAR(30)");

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(180)
                   .HasColumnName("email")
                   .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.Phone)
                   .HasMaxLength(14)
                   .HasColumnName("phone")
                   .HasColumnType("VARCHAR(14)");

            builder.Property(x => x.Avatar)
                   .HasMaxLength(180)
                   .HasColumnName("avatar")
                   .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.QRCode)
                   .HasMaxLength(180)
                   .HasColumnName("qrcode")
                   .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.IsPresent)
                   .IsRequired()
                   .HasColumnName("ispresent")
                   .HasColumnType("Bit");

            builder.Property(x => x.Score)
                   .HasColumnName("score")
                   .HasColumnType("BIGINT");

            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(1000)
                   .HasColumnName("password")
                   .HasColumnType("VARCHAR(1000)");

            builder.Property(x => x.Linkedin)
                   .HasMaxLength(180)
                   .HasColumnName("linkedin")
                   .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.Github)
                   .HasMaxLength(180)
                   .HasColumnName("github")
                   .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.Role)
                   .IsRequired()
                   .HasMaxLength(30)
                   .HasColumnName("role")
                   .HasColumnType("VARCHAR(30)");
        }
    }
}