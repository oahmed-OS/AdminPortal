using DbUp;
using DbUp.Engine;
using System;
using System.Configuration;
using System.Reflection;

namespace AdminPortal.DbUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString =
                ConfigurationManager
                .ConnectionStrings["DevConnection"].ToString();

            //Uncomment if you want DB to be created if doesnt exist
            EnsureDatabase.For.SqlDatabase(connectionString);

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

#if Debug
            Console.ReadLine();
#endif
        }
    }
}
