﻿using Microsoft.EntityFrameworkCore;

namespace BlazorProject.NotesApp.Data;

public interface INoteService
{
    Task Create(Note note);
    Task<Note> FindById(Guid id);
    Task<List<Note>> ReadAll();
    Task Update(Note note);
    Task Delete(Guid id);
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
        _dbContext.Notes.Add(note);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<Note> FindById(Guid id)
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
    
    public async Task Delete(Guid id)
    {
        var note = await _dbContext.Notes.FindAsync(id);
        if (note != null) _dbContext.Notes.Remove(note);
        await _dbContext.SaveChangesAsync();
    }
}
