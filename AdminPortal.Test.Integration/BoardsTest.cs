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

        [SetUp]
        public void Setup()
        {
            var connectionString = TestHelper.GetDevConnection();

            // 1. Reset Tables with Test Data
            TestHelper.ResetDb(connectionString);

            // 2. Initialize Repository
            boardRepository = new BoardRepository(connectionString);
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
        public void GetBoardByDateAndDepartmentIdTest()
        {
            var board = boardRepository.GetDepartmentBoardByDate(1, new DateTime(2019, 1, 1));

            Assert.IsNotNull(board);
            Assert.AreEqual(1, board.Id);
            Assert.AreEqual(1, board.DepartmentId);
            Assert.AreEqual(false, board.IsLock);
            Assert.AreEqual(new DateTime(2019, 1, 1), board.BoardDate);
            Assert.IsNull(board.LockBy);
        }
    }
}