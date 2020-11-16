using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qwirkle.Core.ComplianceContext.Ports;
using Qwirkle.Core.ComplianceContext.Services;
using Qwirkle.Core.GameContext.Ports;
using Qwirkle.Core.GameContext.Services;
using Qwirkle.Core.PlayerContext.Ports;
using Qwirkle.Core.PlayerContext.Services;
using Qwirkle.Infra.Persistance;
using Qwirkle.Infra.Persistance.Adapters;
using Qwirkle.Infra.Persistance.Models;
using System;

namespace Qwirkle.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICompliancePersistance, CompliancePersistanceAdapter>();
            services.AddScoped<IGamePersistance, GamePersistanceAdapter>();
            services.AddScoped<IPlayerPersistance, PlayerPersistanceAdapter>();

            services.AddScoped<IRequestCompliance, ComplianceService>();
            services.AddScoped<IRequestGame, GameService>();
            services.AddScoped<IRequestPlayer, PlayerService>();

            services.AddControllers();

            string persistence = Environment.GetEnvironmentVariable("PERSISTENCE");
            if (persistence == "InMemory")
                services.AddDbContext<DefaultDbContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()), ServiceLifetime.Scoped);
            else if (persistence == "Sqlite")
                services.AddDbContext<DefaultDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("Sqlite")));
            else if (persistence == "SqlServer")
                services.AddDbContext<DefaultDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")), ServiceLifetime.Scoped);
            else
                throw new ArgumentException("No DbContext defined !");

            services.AddIdentity<UserPersistance, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 2;
            })
            .AddRoleManager<RoleManager<IdentityRole<int>>>()
            .AddEntityFrameworkStores<DefaultDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

            services.AddOptions();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Identity/Account/Login");
            services.AddSession();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
#if DEBUG
            app.UseDeveloperExceptionPage();
#else
            app.UseExceptionHandler("/Home/Error");
#endif
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
