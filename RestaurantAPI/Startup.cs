using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.Authorization;
using RestaurantAPI.Entities;
using RestaurantAPI.Middleware;
using RestaurantAPI.Models;
using RestaurantAPI.Models.Validators;
using RestaurantAPI.Services;
using System.Text;

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
            var authenticationSettings = new AuthenticationSettings();
            Configuration.GetSection("Authentication").Bind(authenticationSettings);
            services.AddSingleton(authenticationSettings);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtIssuer)),

                };

            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("HasNationality", builder => builder.RequireClaim("Nationality"));
                options.AddPolicy("Atleast20", builder => builder.AddRequirements(new MinimumAgeRequirement(20)));
                options.AddPolicy("CreatedAtleast2Restaurants",
                    builder => builder.AddRequirements(new CreatedMultipleRestaurantsRequirement(2)));
            });
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, CreatedMultipleRestaurantsRequirementHandler>();
            // Add controllers
            services.AddControllers().AddFluentValidation();

            // Add DbContext for RestaurantDbContext
            services.AddDbContext<RestaurantDbContext>();

            // Add RestaurantSeeder as a scoped service
            services.AddScoped<RestaurantSeeder>();
            services.AddScoped<IUserContextService, UserContextService>();
            // Add AutoMapper with assembly of the current class
            services.AddAutoMapper(this.GetType().Assembly);

            // Add IRestaurantService and its implementation, RestaurantService as scoped services
            services.AddScoped<IRestaurantService, RestaurantService>();

            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen();

            services.AddScoped<RequestTimeMiddleware>();
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
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
            app.UseAuthentication();
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
