namespace BlazorProject.Shared;

public class SharedContext: DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Note> Notes { get; set; }

    public SharedContext()
    {
        //SQLitePCL.Batteries_V2.Init();
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //string dbPath = Path.Combine(FileSystem.AppDataDirectory, "notes.db3");

        //optionsBuilder
        //    .UseSqlite($"Filename={dbPath}");

        optionsBuilder
            .UseSqlServer("Data Source=localhost;Initial Catalog=BlazorProject;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Password2022;");
    }
}

//https://learn.microsoft.com/en-us/ef/core/get-started/xamarin