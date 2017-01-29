using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovalentNet.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CovalentNet
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                //builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
   
            string sqlConnectionString = Configuration["ConnectionStrings:MainConnection"];
            services.AddDbContext<CovalentNet.Data.ApplicationDbContext>(options => {
                options.UseSqlite(sqlConnectionString);
            });

            services.AddScoped(typeof(EntityBaseRepository<,>), typeof(EntityBaseRepository<,>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddMvc();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSwaggerUi();
            //app.UseApplicationInsightsRequestTelemetry();

            //app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();

            DbInitializer.Initialize(app.ApplicationServices);
        }
    }

    public static class DbInitializer
    {
        private static Data.ApplicationDbContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (CovalentNet.Data.ApplicationDbContext)serviceProvider.GetService(typeof(CovalentNet.Data.ApplicationDbContext));
            


        }



        private static void InitializeUserRoles()
        {
           


        }
    }
}
