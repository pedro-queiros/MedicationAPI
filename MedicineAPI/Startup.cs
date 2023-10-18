using Asp.Versioning;
using MedicationAPI.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

namespace MedicationAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            services.AddDbContext<MedicationDb>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            });
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;

            });
            services.AddScoped<IMedicationDb, MedicationDb>();
            services.AddControllers().AddOData(
                options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
                    "odata",
                    modelBuilder.GetEdmModel()));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
        }
    }
}
