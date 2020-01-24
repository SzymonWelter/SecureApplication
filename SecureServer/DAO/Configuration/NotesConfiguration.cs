using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecureServer.Models.DAL;

namespace SecureServer.DAO.Configuration
{
    public class NotesConfiguration : IEntityTypeConfiguration<NoteDAL>
    {
        public void Configure(EntityTypeBuilder<NoteDAL> builder)
        {
            builder.ToTable("Notes");
            builder.HasKey(f => f.NoteId);
            builder.Property(n => n.Title).IsRequired();
            builder.Property(n => n.Text).IsRequired();
            builder.Property(n => n.IsPublic).IsRequired();
        }
    }
}