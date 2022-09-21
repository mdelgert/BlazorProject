namespace BlazorProject.Shared.Services;

public interface INoteService
{
    Task<int> Create(Note note);
    Task<Note?> FindById(int id);
    Task<List<Note?>> ReadAll();
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

    public Task<List<Note?>> ReadAll()
    {
        var notes = _dbContext.Notes.ToList();
        return Task.FromResult(notes);
    }

    public async Task Update(Note note)
    {
        _dbContext.Notes.Update(note);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var note = await _dbContext.Notes.FindAsync(id);
        if (note != null) _dbContext.Notes.Remove(note);
        await _dbContext.SaveChangesAsync();
    }
}
