using boatappapi.Connector;
using boatappapi.Middleware;
using boatappapi.Service.Boat;
using boatappapi.Service.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace boatappapi
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
            services.AddControllers();

            services.AddDbContext<DbDoemuDataContext>(
               o => o.UseNpgsql(Configuration.GetConnectionString("DbDoemu")));

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBoatService, BoatService>();

            services.AddCors(options =>
            {
                options.AddPolicy("OpenPolicy",
                                    builder =>
                                    {
                                        builder.AllowAnyOrigin()
                                               .AllowAnyMethod()
                                               .AllowAnyHeader();
                                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("OpenPolicy"); 
            
            app.UseRouting();

            app.UseAuthentication();

            app.UseMiddleware<Authorisation>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
