using Microsoft.EntityFrameworkCore;
using RozcestnikApp.Models;

namespace RozcestnikApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Reference> ReferencesDb { get; set; }
        public DbSet<Section> SectionsDb { get; set; }

       
    }
}
