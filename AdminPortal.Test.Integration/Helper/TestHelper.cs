using Microsoft.Extensions.Configuration;
using System.IO;

namespace AdminPortal.Test.Integration.Helper
{
    public static class TestHelper
    {
        public static string GetDevConnection()
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
