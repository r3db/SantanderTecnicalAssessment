using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Santander
{
    internal static class Program
    {
        private static void Main()
        {
            WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}