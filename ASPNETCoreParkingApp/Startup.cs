using ASPNETCoreParkingApp.Models;
using ASPNETCoreParkingApp.Models.Repositories.implementation;
using ASPNETCoreParkingApp.Models.Repositories.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNETCoreParkingApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Dependency Injection
            // Application Context
            services.AddDbContext<ParkingAppContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));   // options => options.UseSqlite("Data Source=blog.db")

            // Repositories
            services.AddTransient<IDailyRateRepository, DailyRateRepository>();
            services.AddTransient<IFlatParkingRateRepository, FlatParkingRateRepository>();
            services.AddTransient<IHourlyRateRepository, HourlyRateRepository>();

            // MVC Framework
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
