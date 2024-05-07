using MCData.Entities;
using MCRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MCRepositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        protected DbSet<T> DbSet { get; set; }
        protected DbContext Context { get; private set; }
        public Repository(DbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context), "An instance of DbContext is required to use this repo.");
            this.DbSet = context.Set<T>();
        }

        public virtual void ActivateDeactivate(T entity)
        {
            entity.IsActive = !entity.IsActive;
            this.Update(entity);
        }

        public virtual void ActivateDeactivate(int id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                ActivateDeactivate(entity);
            }
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public IEnumerable<T> GetAll(bool isActive)
        {
            var query = DbSet.AsQueryable();
            return SoftDeleteQueryFilter(query, isActive);
        }

        public T GetById(int id, bool isActive = true)
        {
            return DbSet.Find(id);
        }

        public void Insert(T entity)
        {
            entity.CreatedBy = "Me";
            entity.CreatedOn = DateTime.UtcNow;
            EntityEntry<T> entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                DbSet.AddAsync(entity);
            }
        }

        public void Update(T entity, string excludeProperties = "")
        {
            entity.UpdatedOn = DateTime.UtcNow;
            entity.UpdatedBy = "Me";
            EntityEntry<T> entry = Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;
            entry.Property("CreatedBy").IsModified = false;
            entry.Property("CreatedOn").IsModified = false;
            foreach (var property in excludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                entry.Property(property).IsModified = false;
            }
        }
        public virtual void Save(T entity)
        {
            if (entity.Id == 0)
            {
                Insert(entity);
            }
            else
            {
                Update(entity);
            }
        }
        private static IQueryable<T> SoftDeleteQueryFilter(IQueryable<T> query, bool? isActive)
        {
            if (isActive.HasValue)
            {
                query = query.Where(x => x.IsActive == isActive.Value);
            }
            return query;
        }
    }
}
