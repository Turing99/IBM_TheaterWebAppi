using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Services.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //add a new line to a table
        TEntity Add(TEntity entity);

        //add multiple rows to a table
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        //it waits to generate an expression for which it will return a certain result
        TEntity FindDefault(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();

        TEntity Get(Guid id);

        TEntity Remove(TEntity entity);

        //delete multiple entities
        IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities);




    }
}
