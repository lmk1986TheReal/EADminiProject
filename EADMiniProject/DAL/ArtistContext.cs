using EADMiniProject.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EADMiniProject.DAL
{
    public class ArtistContext : DbContext
    {

        public ArtistContext() : base("ArtistContext")
        {
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}