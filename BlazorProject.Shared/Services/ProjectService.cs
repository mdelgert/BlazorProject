namespace BlazorProject.Shared.Services;

public interface IProjectService
{
    Task Create(Project project);
    Task<List<Project>> ReadAll();
    Task Update(Project project);
    Task Delete(Guid id);
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
    
    public async Task Update(Project project)
    {
        _dbContext.Entry(project).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    
    public Task<List<Project>> ReadAll()
    {
        var projects = _dbContext.Projects.ToList();
        return Task.FromResult(projects);
    }
    
    public async Task Delete(Guid id)
    {
        var project = await _dbContext.Projects.FindAsync(id);
        if (project != null) _dbContext.Projects.Remove(project);
        await _dbContext.SaveChangesAsync();
    }
}
