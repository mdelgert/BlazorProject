namespace BlazorProject.Tests.Services;

public class ProjectServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IProjectService _projectService;
    private const int BatchSize = 10;

    public ProjectServiceTests(ITestOutputHelper testOutputHelper, IProjectService projectService)
    {
        _testOutputHelper = testOutputHelper;
        _projectService = projectService;
    }
    
    [Fact]
    public async Task CreateTest()
    {
        for (var i = 1; i <= BatchSize; i++)
        {
            var project = new Project
            {
                Title = $"Title{i}",
                Name = $"Name{i}"
            };
            await _projectService.Create(project);
        }
    }

    [Fact]
    public async Task ReadAllTest()
    {
        var projects = await _projectService.ReadAll();
        
        foreach (var project in projects)
        {
            _testOutputHelper.WriteLine(project.Name);    
        }
    }
    
}
