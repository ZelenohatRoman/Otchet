using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPTSobj.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using RPTSobj.ApplicationServices.GetMetroLineListUseCase;
using RPTSobj.ApplicationServices.Ports.Gateways.Database;
using RPTSobj.ApplicationServices.Repositories;
using RPTSobj.DomainObjects.Ports;

namespace RPTSobj.WebService
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
            services.AddDbContext<RPTSobjContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "RPTSobj.db")}")
            );

            services.AddScoped<IRPTSobjDatabaseGateway, RPTSobjEFSqliteGateway>();

            services.AddScoped<DbRPTSobjRepository>();
            services.AddScoped<IReadOnlyRPTSobjRepository>(x => x.GetRequiredService<DbRPTSobjRepository>());
            services.AddScoped<IRPTSobjRepository>(x => x.GetRequiredService<DbRPTSobjRepository>());


            services.AddScoped<IGetRPTSobjListUseCase, GetRPTSobjListUseCase>();

            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}