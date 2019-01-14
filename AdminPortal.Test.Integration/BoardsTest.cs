using AdminPortal.Data.Model;
using AdminPortal.Data.Repository;
using AdminPortal.Test.Integration.Helper;
using Dapper;
using NUnit.Framework;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace Tests
{
    public class BoardsTest
    {
        private BoardRepository boardRepository;

        [SetUp]
        public void Setup()
        {
            var connectionString = TestHelper.GetDevConnection();

            string scriptText = GetScript("SetupTest.sql");
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                con.Execute(scriptText);
            }

            // 2. Initialize Repository
            boardRepository = new BoardRepository(connectionString);

        }

        [Test]
        public void GetBoardByIdTest()
        {
            var board = boardRepository.GetEntityById(1);

            Assert.IsNotNull(board);
            Assert.AreEqual(board.Id, 1);
            Assert.AreEqual(board.DepartmentId, 1);
            Assert.AreEqual(board.IsLock, false);
        }

        //Reference: https://stackoverflow.com/questions/1379195/executing-a-sql-script-stored-as-a-resource
        private string GetScript(string fileName)
        {
            string commandText;
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            using (Stream s = thisAssembly.GetManifestResourceStream(
                  "AdminPortal.Test.Integration.Script." + fileName))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    commandText = sr.ReadToEnd();
                }
            }

            return commandText;
        }
    }
}