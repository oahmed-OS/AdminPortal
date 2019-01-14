using AdminPortal.Data.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AdminPortal.Data.Repository
{
    class BaseRepository : IBaseRepository<ITypeWithId>
    {
        private readonly string _CONNECTIONSTRING;
        private readonly string _DESTINATION;

        public BaseRepository(string connectionString, string destination)
        {
            _CONNECTIONSTRING = connectionString;
            _DESTINATION = destination;
        }
        
        public ITypeWithId GetEntityById(int IdParam)
        {
            ITypeWithId result;

            var sql = "SELECT * FROM " + _DESTINATION + " WHERE Id = @Id";

            using (IDbConnection con = new SqlConnection(_CONNECTIONSTRING))
            {
                result = con.Query<ITypeWithId>(sql, new { Id = IdParam })
                    .SingleOrDefault();
            }

            return result;
        }

        public IEnumerable<ITypeWithId> Execute(Func<IDbConnection, IEnumerable<ITypeWithId>> query)
        {
            IEnumerable<ITypeWithId> result;

            using (IDbConnection con = new SqlConnection(_CONNECTIONSTRING))
            {
                result = query.Invoke(con);
            }

            return result;
        }
    }
}
