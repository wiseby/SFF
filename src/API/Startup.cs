using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Products;
using Application.Customers;
using Domain;
using Microsoft.Net.Http.Headers;
using Application.RentService;

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
            services.AddScoped<IProductHandler<Movie>, MovieHandler>();
            services.AddScoped<ICustomerHandler<Studio>, StudioHandler>();
            services.AddSingleton<IRentService, RentService>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("Sqlite"));
            });
            services.AddCors(policy =>
            {
                policy.AddPolicy(
                    "DefaultCors",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            
            services.AddMvc(options =>
            {
             options.FormatterMappings.SetMediaTypeMappingForFormat
            ("xml", MediaTypeHeaderValue.Parse("application/xml"));
            options.FormatterMappings.SetMediaTypeMappingForFormat
            ("config", MediaTypeHeaderValue.Parse("application/xml"));
             options.FormatterMappings.SetMediaTypeMappingForFormat
            ("js", MediaTypeHeaderValue.Parse("application/json"));
             })
            .AddXmlSerializerFormatters();
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
