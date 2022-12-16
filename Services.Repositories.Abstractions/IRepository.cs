using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    public interface IRepository { }
    public interface IRepository<T, TPrimaryKey> : IReadRepository<T, TPrimaryKey>
        where T : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(TPrimaryKey id);


        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(T entity);

        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Добавиь коллекцию сущностей
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        void AddCollection(IEnumerable<T> entities);

        /// <summary>
        /// Сохранить изменения в БД
        /// </summary>
        void SaveChanges();

    }
}
