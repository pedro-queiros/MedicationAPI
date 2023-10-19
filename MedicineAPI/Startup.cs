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
    /// <summary>
    /// The Startup class to setup the initial configuration.
    /// </summary>
    public class Startup
    {
        #region Attributes

        private IConfiguration Configuration { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext
            services.AddDbContext<MedicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            });

            // Add Scoped services
            services.AddScoped<IRepository<Medication>, RepositoryMedication>();
            services.AddScoped<IServiceMedication, ServiceMedication>();

            // Add versioning
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;

            });

            services.AddMvc(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });

            // Add controllers and OData
            ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
            services.AddControllers().AddOData(
                options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
                    "odata",
                    modelBuilder.GetEdmModel()));

            // Add Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
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
