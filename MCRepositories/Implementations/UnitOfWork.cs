using MCRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCRepositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public DbContext Context { get { return _context; } }
        public IMoviesRepository Movies { get; set; }
        public IGenreRepository Genre { get; set; }
        public UnitOfWork(DbContext context)
        {
            this._context = context;
            Movies = new MoviesRepository(context);
            Genre = new GenreRepository(context);
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
