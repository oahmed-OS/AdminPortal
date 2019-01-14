using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AdminPortal.Data.Model;

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
