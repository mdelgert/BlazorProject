using BlazorProject.Shared.Services;
using Bogus;
using Bogus.DataSets;

namespace BlazorProject.Tests.Services;

public class ContactServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IContactService _contactService;
    
    public ContactServiceTests(ITestOutputHelper testOutputHelper, IContactService contactService)
    {
        _testOutputHelper = testOutputHelper;
        _contactService = contactService;
    }
    
    [Fact]
    public async Task CreateContactsTest()
    {
        for (var i = 1; i <= 10; i++)
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
            
            // await using var context = new SharedContext();
            // context.Contacts.Add(contact);
            // var contactId = await context.SaveChangesAsync();
            // _testOutputHelper.WriteLine($"{contact.Contactid} {contact.FirstName}");

        }
    }
    
    [Fact]
    public void ReadContactsTest()
    {

    }
    
    [Fact]
    public void UpdateContactsTest()
    {

    }
    
    [Fact]
    public void DeleteContactsTest()
    {

    }
}
