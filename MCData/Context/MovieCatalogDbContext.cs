using MCData.Entities;
using Microsoft.EntityFrameworkCore;

namespace MCData.Context
{
    public class MovieCatalogDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public MovieCatalogDbContext(DbContextOptions<MovieCatalogDbContext> options) : base(options)
        {

        }
    }
}
