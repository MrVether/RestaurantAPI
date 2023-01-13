using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RestaurantAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //This function is the entry point of the application
            //It creates an instance of IHostBuilder, which is used to configure and build the host for the application
            //and then runs the application.
            CreateHostBuilder(args).Build().Run();
        }

        //This function creates a default host builder using the provided arguments
        //and configures it to use the Startup class for startup configuration.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
