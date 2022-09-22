using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorProject.NotesApp.Data;

public class NoteContext: DbContext
{
    IConfiguration configuration;
    public DbSet<Note> Notes { get; set; }
    
    public NoteContext(IConfiguration config)
    {
        configuration = config;
        //SQLitePCL.Batteries_V2.Init();
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // var dbPath = Path.Combine(FileSystem.AppDataDirectory, "notes.db3");
        //
        // optionsBuilder
        //     .UseSqlite($"Filename={dbPath}");

        // optionsBuilder
        //     .UseSqlServer("Data Source=localhost;Initial Catalog=NoteApp;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Password2022;");
        
        optionsBuilder
            .UseCosmos(
                "https://localhost:8081",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                databaseName: "NoteApp");
        
        // optionsBuilder
        //     .UseCosmos(
        //         Environment.GetEnvironmentVariable("CosmosEndpoint") ?? throw new InvalidOperationException(),
        //         Environment.GetEnvironmentVariable("CosmosKey") ?? throw new InvalidOperationException(),
        //         databaseName: "NoteApp");
        
        //https://montemagno.com/dotnet-maui-appsettings-json-configuration/
        
        // var settings = configuration.GetRequiredSection("Settings").Get<Settings>();
        //
        // optionsBuilder
        //     .UseCosmos(
        //         settings.CosmosEndpoint,
        //         settings.CosmosKey,
        //         databaseName: "NoteApp");
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Note>().ToContainer("Notes");
    }
}
