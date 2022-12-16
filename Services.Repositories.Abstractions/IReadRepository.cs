using Domain.Entities;

namespace Services.Repositories.Abstractions
{

    public interface IReadRepository<T, TPrimaryKey> : IRepository where T : IEntity<TPrimaryKey>
    {
        IQueryable<T> GetAll();


        T Get(TPrimaryKey id);

    }
}