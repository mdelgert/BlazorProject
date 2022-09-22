using Microsoft.EntityFrameworkCore;

namespace BlazorProject.NotesApp.Data;

public interface INoteService
{
    Task Create(Note note);
    Task<Note> FindById(int id);
    Task<List<Note>> ReadAll();
    Task Update(Note note);
    Task Delete(int id);
}

public class NoteService: INoteService
{
    private readonly NoteContext _dbContext;
    
    public NoteService(NoteContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Create(Note note)
    {
        if (_dbContext.Database.IsCosmos())
        {
            //note.NoteId = _dbContext.Notes.Any() ? _dbContext.Notes.Max(x => x.NoteId) : 1;

            if (_dbContext.Notes.Count() > 0)
            {
                note.NoteId = _dbContext.Notes.Max(x => x.NoteId) + 1;
            }
            else
            {
                note.NoteId = 1;
            }
            
        }
        
        _dbContext.Notes.Add(note);

        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<Note> FindById(int id)
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