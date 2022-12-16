using Services.Repositories.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    public abstract class ReadRepository<T, TPrimaryKey> : IReadRepository<T, TPrimaryKey> where T : class, IEntity<TPrimaryKey>
    {

        protected readonly DbContext context;
        protected DbSet<T> EntitySet;

        protected ReadRepository(DbContext context)
        {
            this.context = context;
            EntitySet = this.context.Set<T>();
        }

        public virtual T Get(TPrimaryKey id)
        {
            return EntitySet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return EntitySet;
        }

    }
}