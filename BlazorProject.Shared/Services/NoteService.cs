using Bogus;

namespace BlazorProject.Shared.Services;

public interface INoteService
{
    Task DeleteAll();
    Task CreateFakes(int batchSize);
    Task<int> Create(Note note);
    Task<Note?> FindById(int id);
    Task<List<Note>> ReadAll();
    Task Update(Note note);
    Task Delete(int id);
}

public class NoteService: INoteService
{
    private readonly SharedContext _dbContext;

    public NoteService(SharedContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteAll()
    {
        var notes = await ReadAll();
        
        foreach (var note in notes.Where(contact => true))
        {
            await Delete(note.NoteId);
        }
    }

    public async Task CreateFakes(int batchSize)
    {
        for (var i = 1; i <= batchSize; i++)
        {
            var faker = new Faker();
            var note = new Note
            {
                Title = faker.Lorem.Word(),
                Message = faker.Lorem.Paragraph()
            };
            await Create(note);
        }
    }
    
    public async Task<int> Create(Note note)
    {
        _dbContext.Notes.Add(note);
        var id = await _dbContext.SaveChangesAsync();
        return id;
    }
    
    public async Task<Note?> FindById(int id)
    {
        var note = await _dbContext.Notes.FindAsync(id);
        return note;
    }

    public Task<List<Note>> ReadAll()
    {
        var notes = _dbContext.Notes.ToList();
        return Task.FromResult(notes);
    }
    
    public async Task Update(Note note)
    {
        _dbContext.Entry(note).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task Delete(int id)
    {
        var note = await _dbContext.Notes.FindAsync(id);
        if (note != null) _dbContext.Notes.Remove(note);
        await _dbContext.SaveChangesAsync();
    }
}

// public async Task<int> Update(Note note)
// {
//     // _dbContext.Entry(note).State = EntityState.Modified;
//     // _dbContext.SaveChanges();
//     // return Task.CompletedTask;
//     
//     _dbContext.Notes.Update(note);
//     var id = await _dbContext.SaveChangesAsync();
//     return id;
// }
    
//public async Task<int> Update(Note note)
//{
//    //_dbContext.Notes.Update(note);
//    //await _dbContext.SaveChangesAsync();

//    //_dbContext.Notes.Update(note);
//    //_dbContext.SaveChanges();
//    //return Task.CompletedTask;

//    _dbContext.Update(note);

//    var id = await _dbContext.SaveChangesAsync();

//    return id;
//}


//https://www.thecodebuzz.com/efcore-dbcontext-cannot-access-disposed-object-net-core/
