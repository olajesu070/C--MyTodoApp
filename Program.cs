using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MyTodoApp  // Ensure this matches the namespace in Startup.cs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();  // This should point to the correct Startup class
                });
    }
}
