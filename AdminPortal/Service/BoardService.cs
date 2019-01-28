using AdminPortal.Data.Model;
using AdminPortal.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminPortal.Service
{
    public class BoardService
    {
        IBoardRepository boardRepository;

        public BoardService(IBoardRepository boardRepository)
        {
            this.boardRepository = boardRepository;
        }

        public Board GetDepartmentBoardByDate(int DepartmentId, DateTime Date)
        {
            return boardRepository.GetDepartmentBoardByDate(DepartmentId, Date);
        }

        //TODO: Implement Method
        // Returns: true if locked, false otherwise
        public bool LockBoard(int BoardId, string LockBy)
        {
            //Grab Board
            var board = boardRepository.GetBoardById(BoardId);

            //Ensure Board is Not Locked


            //Lock Board



            return false;
        }
    }
}
