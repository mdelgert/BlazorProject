namespace BlazorProject.Shared.Services;

public interface IContactService
{
    Task Create(Contact contact);
    Task<List<Contact>> ReadAll();
    Task Update(Contact contact);
    Task Delete(Contact contact);
}

public class ContactService : IContactService
{
    private readonly SharedContext _dbContext;

    public ContactService(SharedContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Create(Contact contact)
    {
        _dbContext.Contacts.Add(contact);
        await _dbContext.SaveChangesAsync();
    }
    
    public Task<List<Contact>> ReadAll()
    {
        var contacts = _dbContext.Contacts.ToList();
        return Task.FromResult(contacts);
    }
    
    public async Task Update(Contact contact)
    {
        _dbContext.Contacts.Update(contact);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task Delete(Contact contact)
    {
        _dbContext.Contacts.Remove(contact);
        await _dbContext.SaveChangesAsync();
    }
    
}
