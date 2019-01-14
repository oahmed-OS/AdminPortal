using DbUp;
using DbUp.Engine;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace AdminPortal.DbUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = GetDevConnection();

            //Uncomment if you want DB to be created if doesnt exist
            //EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();


            var result = upgrader.PerformUpgrade();

            OutputResult(result);
        }

        private static void OutputResult(DatabaseUpgradeResult result)
        {
            if (result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
            }


            Console.ResetColor();

#if DEBUG
            Console.ReadLine();
#endif
        }

        private static string GetDevConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("77f57984-3b7a-4904-acc1-c6a4367ea62a")
                .Build();

            return builder.GetConnectionString("DevConnection");
        }
    }
}
