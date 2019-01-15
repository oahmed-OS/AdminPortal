using AdminPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AdminPortal.Data.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class, ITypeWithId
    {
        TEntity GetEntityById(int Id);

        Task<TEntity> GetEntityByIdAsync(int Id);

        IEnumerable<TEntity> Execute(Func<IDbConnection, 
            IEnumerable<TEntity>> query);

        //Task<IEnumerable<TEntity>> ExecuteAsync(Func<IDbConnection,
        //    IEnumerable<TEntity>> query);
    }
}
