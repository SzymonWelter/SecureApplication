using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecureServer.Models.DAL;

namespace SecureServer.DAO.Configuration
{
    public class UsersConfiguration :  IEntityTypeConfiguration<UserDAL>
    {
        public void Configure(EntityTypeBuilder<UserDAL> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Username).IsRequired();
            builder.Property(u => u.Password).IsRequired();

            builder.HasMany(u => u.Notes).WithOne(n => n.User).OnDelete(DeleteBehavior.Restrict);
        }
    }
}