using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityRelation.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}
