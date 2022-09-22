namespace BlazorProject.Shared;

public class SharedContext: DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Project> Projects { get; set; }

    public SharedContext()
    {
        //SQLitePCL.Batteries_V2.Init();
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //string dbPath = Path.Combine(FileSystem.AppDataDirectory, "notes.db3");

        //optionsBuilder
        //    .UseSqlite($"Filename={dbPath}");

        // optionsBuilder
        //     .UseSqlServer("Data Source=localhost;Initial Catalog=BlazorProject;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Password2022;");
        
        optionsBuilder
            .UseCosmos(
                "https://localhost:8081",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                databaseName: "BlazorProject");
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultContainer("Demo");
        builder.Entity<Contact>().ToContainer("Contacts");
        builder.Entity<Note>().ToContainer("Notes");
        builder.Entity<Project>().ToContainer("Projects");
    }
}

//https://learn.microsoft.com/en-us/ef/core/get-started/xamarin
//https://learn.microsoft.com/en-us/ef/core/providers/cosmos/?tabs=dotnet-core-cli