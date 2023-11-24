using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sibers.Core.Repositories;
using Sibers.Core.Repositories.Base;
using Sibers.Data;
using Sibers.Data.Entities.Classes;
using System.Reflection.Metadata;

namespace Sibers.Web
{
    /// <summary>
    /// Настройка приловжения
    /// </summary>
    public static class ServiceExtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration pConfiguration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<SibersDbContext>(options => options.UseNpgsql(pConfiguration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
            
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SibersDbContext>();
            services.AddScoped<ISibersRepository<Assignment>, SibersRepository<Assignment>>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        }

        public static async Task ConfigureApplicationAsync(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            using var scope=app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            await SeedData.CreateInitialData(scope.ServiceProvider);
            app.Run();
        }
    }
}
