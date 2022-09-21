namespace BlazorProject.Tests;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
    {
        var sharedContext = new SharedContext();
        services.AddSingleton(_ => sharedContext);
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<INoteService, NoteService>();

        services.AddLogging(loggerBuilder =>
        {
            loggerBuilder.ClearProviders();
            loggerBuilder.AddConsole();
            loggerBuilder.AddFile("Serilog\\debug.log");
        });
    }
}
