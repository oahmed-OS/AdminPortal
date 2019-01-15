using AdminPortal.Data.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, ITypeWithId
    {
        private readonly string _CONNECTIONSTRING;
        private readonly string _DESTINATION;

        public BaseRepository(string connectionString, string destination)
        {
            _CONNECTIONSTRING = connectionString;
            _DESTINATION = destination;
        }
        
        public TEntity GetEntityById(int IdParam)
        {
            TEntity result;

            var sql = "SELECT * FROM " + _DESTINATION + " WHERE Id = @Id";

            using (IDbConnection con = new SqlConnection(_CONNECTIONSTRING))
            {
                result = con.Query<TEntity>(sql, new { Id = IdParam })
                    .SingleOrDefault();
            }

            return result;
        }

        public async Task<TEntity> GetEntityByIdAsync(int IdParam)
        {
            TEntity result;

            var sql = "SELECT * FROM " + _DESTINATION + " WHERE Id = @Id";

            using (IDbConnection con = new SqlConnection(_CONNECTIONSTRING))
            {
                var queryResult = await con.QueryAsync<TEntity>(sql, new { Id = IdParam });
                result = queryResult.SingleOrDefault();
            }

            return result;
        }

        public IEnumerable<TEntity> Execute(Func<IDbConnection, IEnumerable<TEntity>> query)
        {
            IEnumerable<TEntity> result;

            using (IDbConnection con = new SqlConnection(_CONNECTIONSTRING))
            {
                result = query.Invoke(con);
            }

            return result;
        }

        //public Task<IEnumerable<TEntity>> ExecuteAsync(Func<IDbConnection, IEnumerable<TEntity>> query)
        //{
        //    IEnumerable<TEntity> result = null;

        //    using (IDbConnection con = new SqlConnection(_CONNECTIONSTRING))
        //    {

        //        var tmp = query.BeginInvoke(con, queryAsyncResult =>
        //        {
        //            result = query.EndInvoke(queryAsyncResult);
        //        }, null);
                
        //    }

        //    return result;
        //}
    }
}
