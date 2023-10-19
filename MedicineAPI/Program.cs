using MedicationAPI;

/// <summary>
/// Program class containing the main function
/// </summary>
public static class Program
{
    #region Main Function

    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var startup = new Startup(builder.Configuration);
        startup.ConfigureServices(builder.Services);

        var app = builder.Build();
        startup.Configure(app, app.Environment);
        app.MapControllers();

        app.Run();
    }

    #endregion
}