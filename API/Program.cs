using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)//Those inside the Main happens before the starting of the application
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            //We are outside our middleware so need to have a try catch here

            try {
                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
                await Seed.SeedUsers(context);
            }catch(Exception ex){
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex,"An error occured during migration");
            }
            await host.RunAsync(); 
            //CreateHostBuilder(args).Build().RunAsync();// What we
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
