using Newtonsoft.Json;

namespace BlazorProject.Shared.Models;

public class Project
{
    //public int ProjectId { get; set; }
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Name { get; set; }
}

//https://stackoverflow.com/questions/43503424/error-the-entity-type-requires-a-primary-key
//https://corebts.com/blog/azure-cosmos-document-ids/