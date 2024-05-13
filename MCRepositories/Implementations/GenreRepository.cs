using MCData.Entities;
using MCRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCRepositories.Implementations
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(DbContext context) : base(context)
        {
        }
    }
}
