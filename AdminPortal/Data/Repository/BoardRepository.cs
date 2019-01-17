using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AdminPortal.Data.Model;
using Dapper;

namespace AdminPortal.Data.Repository
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        private readonly string _CONNECTIONSTRING;

        public BoardRepository(string connectionString)
            : base(connectionString, "Boards")
        {
            _CONNECTIONSTRING = connectionString;
        }

        public Board GetDepartmentBoardByDate(int DepartmentId, DateTime BoardDate)
        {
            Board result;

            var sql = "SELECT * FROM Boards WHERE DepartmentId = @Id AND BoardDate = @Date";

            using (IDbConnection con = new SqlConnection(_CONNECTIONSTRING))
            {
                result = con.Query<Board>(sql, new { Id = DepartmentId, Date = BoardDate })
                    .SingleOrDefault();
            }

            return result;

        }

        public void LockBoard(int BoardId, string LockUser)
        {
            var sql = "UPDATE Boards SET IsLock = 1, LockBy = @User WHERE Id = @Id";

            using (IDbConnection con = new SqlConnection(_CONNECTIONSTRING))
            {
                con.Query(sql, new { User = LockUser, Id = BoardId });
            }
        }

        public void UnlockBoard(int BoardId)
        {
            var sql = "UPDATE Boards SET IsLock = 0, LockBy = null WHERE Id = @Id";

            using (IDbConnection con = new SqlConnection(_CONNECTIONSTRING))
            {
                con.Query(sql, new { Id = BoardId });
            }
        }
    }
}
