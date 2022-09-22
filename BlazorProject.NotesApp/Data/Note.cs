namespace BlazorProject.NotesApp.Data;

public class Note
{
    //public Guid Id { get; set; }
    public int NoteId { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }
}
