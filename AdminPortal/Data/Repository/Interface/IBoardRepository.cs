using AdminPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminPortal.Data.Repository
{
    public interface IBoardRepository 
    {
        Board GetDepartmentBoardByDate(int DepartmentId, DateTime Date);

        void LockBoard(int BoardId, string LockUser);

        void UnlockBoard(int BoardId);

        //void UpdateBoardDetail();
    }
}
