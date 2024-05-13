using MCData.Entities;

namespace MCRepositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll(bool isActive);
        Task<T> GetById(int id, bool isActive = true);
        void Save(T entity);
        void Insert(T entity);
        void Update(T entity, string excludeProperties = "");
        void ActivateDeactivate(T entity);
        void ActivateDeactivate(int id);
        void Delete(T entity);
        void Delete(int id);
    }
}
