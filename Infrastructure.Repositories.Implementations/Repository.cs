using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    public abstract class Repository<T, TPrimatyKey> : ReadRepository<T, TPrimatyKey>,
        IRepository<T, TPrimatyKey> where T : class, IEntity<TPrimatyKey>
    {

        protected Repository(DbContext context):base(context)
        {

        }
        public virtual T Add(T entity)
        {
            var objToReturn = EntitySet.Add(entity);
            return objToReturn.Entity;
        }

        public virtual void AddCollection(IEnumerable<T> entities)
        {
            if(entities == null || !entities.Any())
            {
                return;
            }
            EntitySet.AddRange(entities);
        } 
        public virtual bool Delete(TPrimatyKey id)
        {
            var obj = EntitySet.Find(id);
            if (obj == null)
                return false;
            EntitySet.Remove(obj);
            return true;
        }
        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified; 
        }
        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
