using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantAPI.Entities;
using RestaurantAPI.Middleware;
using RestaurantAPI.Services;

namespace RestaurantAPI
{
    // Startup class for configuring the application
    public class Startup
    {
        // Constructor for initializing the Configuration property
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Property for storing the configuration
        public IConfiguration Configuration { get; }

        // Method for configuring services
        public void ConfigureServices(IServiceCollection services)
        {
            // Add controllers
            services.AddControllers();

            // Add DbContext for RestaurantDbContext
            services.AddDbContext<RestaurantDbContext>();

            // Add RestaurantSeeder as a scoped service
            services.AddScoped<RestaurantSeeder>();

            // Add AutoMapper with assembly of the current class
            services.AddAutoMapper(this.GetType().Assembly);

            // Add IRestaurantService and its implementation, RestaurantService as scoped services
            services.AddScoped<IRestaurantService, RestaurantService>();

            services.AddScoped<ErrorHandlingMiddleware>();

            services.AddSwaggerGen();

            services.AddScoped<RequestTimeMiddleware>();
        }

        // Method for configuring the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RestaurantSeeder seeder)
        {
            // Seed data to the database
            seeder.Seed();

            // Check if the environment is development
            if (env.IsDevelopment())
            {
                // Use developer exception page
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<RequestTimeMiddleware>();
            // Use HTTPS redirection
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {


                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API");
            });

            // Use routing
            app.UseRouting();

            // Use authorization
            app.UseAuthorization();

            // Use endpoints
            app.UseEndpoints(endpoints =>
            {
                // Map controllers to endpoints
                endpoints.MapControllers();
            });
        }
    }
}
