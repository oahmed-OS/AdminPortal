using AdminPortal.Data.Model;
using AdminPortal.Data.Repository;
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
            var connectionString = ConfigurationManager.ConnectionStrings["DevConnection"]
                .ConnectionString;

            // 1. Prepare Db By reseting & populating test data
            string scriptText = GetScript("SetupTest.sql");
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                con.Execute(scriptText);
            }

            // 2. Initialize Repository
            boardRepository = new BoardRepository(connectionString);

        }

        [Test]
        public void UseBaseRepoToGetEmployee()
        {
            var board = boardRepository.GetEntityById(1);

            Assert.IsNotNull(board);
            Assert.Equals(board.Id, 1);
            Assert.Equals(board.DepartmentId, 1);
            Assert.Equals(board.IsLock, false);

            Assert.Pass();
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