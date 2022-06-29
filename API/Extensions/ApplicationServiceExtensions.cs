using API.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Services;
using API.Helpers;

namespace API.Extensions
{ 
    public static class ApplicationServiceExtensions//static refers to that we do not need an instance created inorder to use the properties of this class
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services, IConfiguration config)
        {
            //can add a service as a singleton [Addsingleton] which doesn't stop untill our aplication stops so it continously consumes resources
            //can add a service as scopped [AddScopped] life time is scoppped to the life time of the Http request
            //can add a service as addTransient and used only when needed to create the service and destroy it as soon as the method is finished : not quite riht for an HTTP request
            services.AddScoped<ITokenService, TokenService>();//Tokens are useful when testing plus it's a best practice even though we can get the desired result without interfaces
            services.AddScoped<IUserRepository, UserRepository>();             
            //Lambda Expression
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                //options.UseSqlite("Connection String");//add this configuration inside the appsettings.Development.json file
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
        
    }
}