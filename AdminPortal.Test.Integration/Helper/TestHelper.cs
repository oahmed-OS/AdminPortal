using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace AdminPortal.Test.Integration.Helper
{
    public static class TestHelper
    {
        public static void ResetDb(string connectionString)
        {
            string scriptText = GetScript("SetupTest");
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                con.Execute(scriptText);
            }
        }

        public static void LockBoards(string connectionString)
        {
            string scriptText = GetScript("LockBoards");
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                con.Execute(scriptText);
            }
        }

        public static void UnlockBoards(string connectionString)
        {
            string scriptText = GetScript("UnlockBoards");
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                con.Execute(scriptText);
            }
        }

        //Reference https://stackoverflow.com/questions/42268265/how-to-get-manage-user-secrets-in-a-net-core-console-application
        public static string GetDevConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("77f57984-3b7a-4904-acc1-c6a4367ea62a")
                .Build();

            return builder.GetConnectionString("DevConnection");
        }

        //Reference: https://stackoverflow.com/questions/1379195/executing-a-sql-script-stored-as-a-resource
        private static string GetScript(string fileName)
        {
            string commandText;
            string filePath = "AdminPortal.Test.Integration.Script." + fileName + ".sql";
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            using (Stream s = thisAssembly.GetManifestResourceStream(filePath))
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
