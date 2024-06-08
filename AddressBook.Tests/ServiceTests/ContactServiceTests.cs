using AddressBook.Models;
using AddressBook.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Tests.ServiceTests
{
    public class ContactServiceTests
    {
         private readonly string _testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "test_contacts.json");

        public ContactServiceTests()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
            File.WriteAllText(_testFilePath, "[]");
        }
        private List<Contact> GetTestContacts()
        {
            return new List<Contact>
            {
                 new Contact { Id = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "1234567890", Address = "1 Main Street" },
                new Contact { Id = 2, FirstName = "Barry", LastName = "Long", PhoneNumber = "0987654321", Address = "2 Main Street" },
                new Contact { Id = 2, FirstName = "Alice", LastName = "Smith", PhoneNumber = "9876543210", Address = "3 Main Street" }
            };
        }
        private void WriteTestContactsToFile(List<Contact> contacts)
        {
            var jsonData = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(_testFilePath, jsonData);
        }
        private void CleanUp()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
            File.WriteAllText(_testFilePath, "[]");
        }
        [Fact]
        public void GetAllContacts_ShouldReturnAllContacts()
        {
            WriteTestContactsToFile(GetTestContacts());
            var service = new ContactService(_testFilePath);

            var result = service.GetAllContacts();

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);

            CleanUp();
        }

    }
}
