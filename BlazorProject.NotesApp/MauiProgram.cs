using System.Reflection;
using BlazorProject.NotesApp.Data;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.Configuration;

namespace BlazorProject.NotesApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            

            var builder = MauiApp.CreateBuilder();
            
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            //https://montemagno.com/dotnet-maui-appsettings-json-configuration/
            //var settingsPath = Path.Combine(FileSystem.AppDataDirectory, "local.settings.json");
            
            //EnvironmentHelper.SetupValues("Resources/Raw/local.settings.json");

            //var assembly = Assembly.GetExecutingAssembly();
            //using var stream = assembly.GetManifestResourceStream("appsettings.json");

            // var config = new ConfigurationBuilder()
            //     .AddJsonStream(stream)
            //     .Build();

            //builder.Configuration.AddConfiguration(config);

            builder.Services.AddDbContext<NoteContext>();
            builder.Services.AddSingleton<INoteService, NoteService>();
            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}