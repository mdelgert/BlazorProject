namespace BlazorProject.Shared.Services;

public interface IProjectService
{
    Task Create(Project project);
    Task<List<Project>> ReadAll();
}

public class ProjectService: IProjectService
{
    private readonly SharedContext _dbContext;

    public ProjectService(SharedContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Create(Project project)
    {
        _dbContext.Projects.Add(project);
        await _dbContext.SaveChangesAsync();
    }
    
    public Task<List<Project>> ReadAll()
    {
        var projects = _dbContext.Projects.ToList();
        return Task.FromResult(projects);
    }
}
