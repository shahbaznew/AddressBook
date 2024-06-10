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
                new Contact { Id = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "1234567890", Address = "1 Main Street", Email = "JohnDoe@gmail.com"},
                new Contact { Id = 2, FirstName = "Barry", LastName = "Long", PhoneNumber = "0987654321", Address = "2 Main Street", Email = "BarryLong@gmail.com"},
                new Contact { Id = 3, FirstName = "Alice", LastName = "Smith", PhoneNumber = "9876543210", Address = "3 Main Street", Email = "AliceSmith@gmail.com"}
            };
        }
        private void WriteTestContactsToFile(List<Contact> contacts)
        {
            var jsonData = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(_testFilePath, jsonData);
        }
        [Fact]
        public void GetAllContacts_ShouldReturnAllContacts()
        {
            WriteTestContactsToFile(GetTestContacts());
            var service = new ContactService(_testFilePath);

            var result = service.GetAllContacts();

            Assert.NotNull(result);
            Assert.Equal(4, result.Count);

    
        }
        [Fact]
        public void GetContactByID_ShouldReturnCorrectContact()
        {
            WriteTestContactsToFile(GetTestContacts());
            var service = new ContactService(_testFilePath);
            var contactId = 1;

            var result = service.GetContactID(contactId);
            Assert.NotNull(result);
            Assert.Equal(contactId, result.Id);
       
        }
        [Fact]
        public void GetContactByID_ShouldReturnNull_WhenContactDoesNotExist()
        {
            var service = new ContactService(_testFilePath);
            var result = service.GetContactID(999); 
            Assert.Null(result);
        }
        [Fact]
        public void CreateContact_ShouldAddNewContact()
        {
            WriteTestContactsToFile(GetTestContacts());
            var service = new ContactService(_testFilePath);
            var newContact = new Contact { FirstName = "New", LastName = "Contact", PhoneNumber = "12312312345", Address = "4 Main Street", Email = "newcontact@gmail.com"};

            var createdContact = service.CreateContact(newContact);
            var allContacts = service.GetAllContacts();
            Assert.NotNull(createdContact);
            Assert.Equal(4, allContacts.Count); 
            Assert.Equal("New", createdContact.FirstName);

        }
        [Fact]
        public void UpdateContact_ShouldModifyExistingContact()
        {
          
            WriteTestContactsToFile(GetTestContacts());
            var service = new ContactService(_testFilePath);
            var updateContact = new Contact { Id = 1, FirstName = "Updated", LastName = "Name", PhoneNumber = "12312312345", Address = "Updated Address", Email = "newcontact@gmail.com"};
            var result = service.UpdateContact(updateContact);
            Assert.NotNull(result);
            Assert.Equal("Updated", result.FirstName);
        }
        [Fact]
        public void UpdateContact_ShouldReturnNull_WhenContactDoesNotExist()
        {
            var service = new ContactService(_testFilePath);
            var updateContact = new Contact { Id = 999, FirstName = "Non-Existing", LastName = "Contact", PhoneNumber = "0000000000", Address = "Does not exist", Email = "nonexisting@gmail.com"};
            var result = service.UpdateContact(updateContact);
            Assert.Null(result);
        }
        [Fact]
        public void DeleteContact_ShouldRemoveContact()
        {
            WriteTestContactsToFile(GetTestContacts());
            var service = new ContactService(_testFilePath);
            var contactId = 1;

            var result = service.DeleteContact(contactId);
            var allContacts = service.GetAllContacts();
            Assert.True(result);
            Assert.Equal(3, allContacts.Count);
            Assert.Null(service.GetContactID(contactId));
        }
        [Fact]
        public void DeleteContact_ShouldReturnFalse_WhenContactDoesNotExist()
        {
            var service = new ContactService(_testFilePath);
            var result = service.DeleteContact(999); 
            Assert.False(result);
        }

    }
}
