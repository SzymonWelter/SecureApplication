using System.Linq;
using Microsoft.EntityFrameworkCore;
using SecureServer.DAO.Configuration;
using SecureServer.Models.DAL;

namespace Server.DAO
{
    public class SecureContext : DbContext
    {

        public SecureContext(DbContextOptions options) : base(options) { }
        public DbSet<NoteDAL> Notes { get; set; }
        public DbSet<UserDAL> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfiguration(new NotesConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());

        }

    }
}