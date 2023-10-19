using Asp.Versioning;
using MedicationAPI_BAL.Contracts;
using MedicationAPI_BAL.Services;
using MedicationAPI_DAL.Contracts;
using MedicationAPI_DAL.Data;
using MedicationAPI_DAL.Models;
using MedicationAPI_DAL.Repositories;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

namespace MedicationAPI
{
    public class Startup
    {
        #region Attributes

        public IConfiguration Configuration { get; }

        #endregion

        #region Constructores

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Public Methods

        public void ConfigureServices(IServiceCollection services)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            services.AddDbContext<MedicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            });
            services.AddScoped<IRepository<Medication>, RepositoryMedication>();
            services.AddScoped<IServiceMedication, ServiceMedication>();
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;

            });
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

        #endregion
    }
}
