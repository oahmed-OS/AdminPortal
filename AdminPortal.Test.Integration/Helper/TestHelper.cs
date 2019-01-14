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
            string scriptText = GetResetScript();
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                con.Execute(scriptText);
            }
        }

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
        private static string GetResetScript()
        {
            string commandText;
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            using (Stream s = thisAssembly.GetManifestResourceStream(
                  "AdminPortal.Test.Integration.Script.SetupTest.sql"))
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
