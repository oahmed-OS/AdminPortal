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

        public Board GetDepartmentBoardByDate(int DepartmentId, DateTime Date)
        {
            throw new NotImplementedException();

        }
    }
}
