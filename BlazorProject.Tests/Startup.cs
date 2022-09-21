namespace BlazorProject.Tests;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
    {
        //services.AddDbContext<SharedContext>();
        var sharedContext = new SharedContext();
        services.AddSingleton(_ => sharedContext);
        services.AddSingleton<IContactService, ContactService>();
        services.AddLogging(loggerBuilder =>
        {
            loggerBuilder.ClearProviders();
            loggerBuilder.AddConsole();
            loggerBuilder.AddFile("Serilog\\debug.log");
        });
    }
}
