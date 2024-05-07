using MCData.Entities;
using MCRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCRepositories.Implementations
{
    public class MoviesRepository : Repository<Movie>, IMoviesRepository
    {
        public MoviesRepository(DbContext context) : base(context)
        {

        }
        public override async Task<IEnumerable<Movie>> GetAll(bool isActive)
        {
            return await SoftDeleteQueryFilter(this.DbSet, isActive).Include("Genre").Include("Rating").ToListAsync();
        }
    }
}
