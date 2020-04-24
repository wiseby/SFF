using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Persistence;
using Application.Products;
using Application.Customers;
using Domain;
using Application;

namespace API
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
            services.AddScoped<IProductHandler<MovieDto, MovieDetailDto>, MovieHandler>();
            services.AddScoped<ICustomerHandler<Studio>, StudioHandler>();
            services.AddAutoMapper(typeof(StudioHandler));
            services.AddDbContext<DataContext>(options => {
                options.UseSqlite(Configuration.GetConnectionString("Sqlite"));
                //options.UseInMemoryDatabase(databaseName: "sff");
            });
            services.AddCors(policy => {
                policy.AddPolicy(
                    "DefaultCors", 
                    builder => {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
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

            //app.UseHttpsRedirection();

            app.UseCors("DefaultCors");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
