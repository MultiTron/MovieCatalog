using Microsoft.EntityFrameworkCore;

namespace MCRepositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        IMoviesRepository Movies { get; }
        IGenreRepository Genre { get; }
        Task<int> SaveChangesAsync();
    }
}
