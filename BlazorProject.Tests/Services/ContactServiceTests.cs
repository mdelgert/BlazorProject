using Bogus;
using Bogus.DataSets;

namespace BlazorProject.Tests.Services;

public class ContactServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IContactService _contactService;
    private const int BatchSize = 10;

    public ContactServiceTests(ITestOutputHelper testOutputHelper, IContactService contactService)
    {
        _testOutputHelper = testOutputHelper;
        _contactService = contactService;
    }
    
    [Fact]
    public async Task CreateTest()
    {
        for (var i = 1; i <= BatchSize; i++)
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

            await _contactService.Create(contact);
        }
    }
    
    [Fact]
    public async Task ReadAllTest()
    {
        var contacts = await _contactService.ReadAll();
        foreach (var contact in contacts)
        {
            _testOutputHelper.WriteLine($"{contact.ContactId} {contact.FirstName}");
        }
    }
    
    [Fact]
    public async Task UpdateTest()
    {
        var contacts = await _contactService.ReadAll();
        foreach (var contact in contacts)
        {
            contact.LastName += "-Update";
            await _contactService.Update(contact);
        }
    }
    
    [Fact]
    public async Task DeleteAllTest()
    {
        var contacts = await _contactService.ReadAll();
        foreach (var contact in contacts)
        {
            await _contactService.Delete(contact);
        }
    }
}
