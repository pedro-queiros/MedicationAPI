using MedicationAPI;

/// <summary>
/// The Program class containing the main function.
/// </summary>
public static class Program
{
    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        Startup startup = new Startup(builder.Configuration);
        startup.ConfigureServices(builder.Services);

        WebApplication app = builder.Build();
        startup.Configure(app, app.Environment);
        app.MapControllers();

        app.Run();
    }
}