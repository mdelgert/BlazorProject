namespace BlazorProject.Shared.Services;

public interface IContactService
{
    Task Create(Contact contact);
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
        var contactId = await _dbContext.SaveChangesAsync();
    }
    
}
