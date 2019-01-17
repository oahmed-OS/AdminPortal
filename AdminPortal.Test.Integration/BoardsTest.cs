using AdminPortal.Data.Repository;
using AdminPortal.Test.Integration.Helper;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class BoardsTest
    {
        private BoardRepository boardRepository;
        private string _CONNECTIONSTRING;

        [SetUp]
        public void Setup()
        {
            _CONNECTIONSTRING = TestHelper.GetDevConnection();

            // 1. Reset Tables with Test Data
            TestHelper.ResetDb(_CONNECTIONSTRING);

            // 2. Initialize Repository
            boardRepository = new BoardRepository(_CONNECTIONSTRING);
        }


        [Test]
        public void GetBoardByIdTest()
        {
            var board = boardRepository.GetEntityById(1);

            Assert.IsNotNull(board);
            Assert.AreEqual(1, board.Id);
            Assert.AreEqual(1, board.DepartmentId);
            Assert.AreEqual(false, board.IsLock);
            Assert.AreEqual(new DateTime(2019, 1, 1), board.BoardDate);
            Assert.IsNull(board.LockBy);
        }


        [Test]
        public async Task GetBoardByIdAsyncTest()
        {
            var board = await boardRepository.GetEntityByIdAsync(1);

            Assert.IsNotNull(board);
            Assert.AreEqual(1, board.Id);
            Assert.AreEqual(1, board.DepartmentId);
            Assert.AreEqual(false, board.IsLock);
            Assert.AreEqual(new DateTime(2019, 1, 1), board.BoardDate);
            Assert.IsNull(board.LockBy);
        }

        [Test]
        public void LockBoardTest()
        {
            //Arrange
            TestHelper.UnlockBoards(_CONNECTIONSTRING);
            //Act
            boardRepository.LockBoard(1, "John Doe");
            var board = boardRepository.GetEntityById(1);
            //Assert
            Assert.IsNotNull(board);
            Assert.AreEqual(1, board.Id);
            Assert.AreEqual(1, board.DepartmentId);
            Assert.AreEqual(true, board.IsLock);
            Assert.AreEqual(new DateTime(2019, 1, 1), board.BoardDate);
            Assert.AreEqual("John Doe", board.LockBy);
        }

        [Test]
        public void UnlockBoardTest()
        {
            //Arrange
            TestHelper.LockBoards(_CONNECTIONSTRING);
            //Act
            boardRepository.UnlockBoard(1);
            var board = boardRepository.GetEntityById(1);
            //Assert
            Assert.IsNotNull(board);
            Assert.AreEqual(1, board.Id);
            Assert.AreEqual(1, board.DepartmentId);
            Assert.AreEqual(false, board.IsLock);
            Assert.AreEqual(new DateTime(2019, 1, 1), board.BoardDate);
            Assert.IsNull(board.LockBy);
        }

        [Test]
        public void GetDepartmentBoardByDateTest()
        {
            var board = boardRepository.GetDepartmentBoardByDate(1, new DateTime(2019, 1, 1));

            Assert.IsNotNull(board);
            Assert.AreEqual(1, board.Id);
            Assert.AreEqual(1, board.DepartmentId);
            Assert.AreEqual(false, board.IsLock);
            Assert.AreEqual(new DateTime(2019, 1, 1), board.BoardDate);
            Assert.IsNull(board.LockBy);
        }

        [Test]
        public void GetDepartmentBoardByDateServiceTest()
        {
            //TODO: Implement Test
            Assert.Pass();
        }
    }
}