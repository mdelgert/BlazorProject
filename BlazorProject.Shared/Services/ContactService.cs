using Bogus;
using Bogus.DataSets;

namespace BlazorProject.Shared.Services;

public interface IContactService
{
    Task DeleteAll();
    Task CreateFakes(int batchSize);
    Task<int> Create(Contact contact);
    Task<Contact?> FindById(int id);
    Task<List<Contact>> ReadAll();
    Task Update(Contact contact);
    Task Delete(int id);
}

public class ContactService : IContactService
{
    private readonly SharedContext _dbContext;

    public ContactService(SharedContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteAll()
    {
        var contacts = await ReadAll();
        
        foreach (var contact in contacts.Where(contact => true))
        {
            await Delete(contact.ContactId);
        }
    }
    
    public async Task CreateFakes(int batchSize)
    {
        for (var i = 1; i <= batchSize; i++)
        {
            var faker = new Faker();
            var phone = new PhoneNumbers();
            var contact = new Contact
            {
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                Address = faker.Person.Address.Street,
                City = faker.Person.Address.City,
                State = faker.Person.Address.State,
                ZipCode = faker.Person.Address.ZipCode,
                PhoneNumber = phone.PhoneNumberFormat(1)
            };
            await Create(contact);
        }
    }
    
    public async Task<int> Create(Contact contact)
    {
        _dbContext.Contacts.Add(contact);
        var id = await _dbContext.SaveChangesAsync();
        return id;
    }
    
    public async Task<Contact?> FindById(int id)
    {
        var contact = await _dbContext.Contacts.FindAsync(id);
        return contact;
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
    
    public async Task Delete(int id)
    {
        var contact = await _dbContext.Contacts.FindAsync(id);
        if (contact != null) _dbContext.Contacts.Remove(contact);
        await _dbContext.SaveChangesAsync();
    }
}
