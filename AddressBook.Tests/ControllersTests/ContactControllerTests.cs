using Microsoft.AspNetCore.Mvc;
using Xunit;
using AddressBook.Controllers;
using AddressBook.Models;
using System.Collections.Generic;

namespace AddressBook.Tests.Controllers
{
    public class ContactsControllerTests
    {
        [Fact]
        public void AllContacts_ShouldReturnOkResultWithContacts()
        {
            var controller = new ContactsController();
            var result = controller.AllContacts();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var contacts = Assert.IsType<List<Contact>>(okResult.Value);
            Assert.Equal(3, contacts.Count);
        }

        [Fact]
        public void GetID_ShouldReturnOkResultWithContact_WhenContactExists()
        {
            var controller = new ContactsController();
            int contactId = 1; 

            var result = controller.GetID(contactId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var contact = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(contactId, contact.Id);
        }

        [Fact]
        public void GetID_ShouldReturnBadRequest_WhenContactDoesNotExist()
        {
            var controller = new ContactsController();
            int nonExistentContactId = 999; 

            var result = controller.GetID(nonExistentContactId);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Contact is not found", badRequestResult.Value);
        }
        [Fact]
        public void UpdateContact_ShouldReturnOkResultWithUpdatedContact_WhenContactExists()
        {
        
            var controller = new ContactsController();
            var updateContact = new Contact
            {
                Id = 1, 
                FirstName = "UpdatedName",
                LastName = "UpdatedLastName",
                PhoneNumber = "46875184641684",
                Address = "Updated Address"
            };

     
            var result = controller.UpdateContact(updateContact);

      
            var okResult = Assert.IsType<OkObjectResult>(result);
            var updatedContact = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(updateContact.FirstName, updatedContact.FirstName);
            Assert.Equal(updateContact.LastName, updatedContact.LastName);       
            Assert.Equal(updateContact.PhoneNumber, updatedContact.PhoneNumber);
            Assert.Equal(updateContact.Address, updatedContact.Address);
        }

        [Fact]
        public void UpdateContact_ShouldReturnBadRequest_WhenContactDoesNotExist()
        {
            var controller = new ContactsController();
            var updateContact = new Contact
            {
                Id = 999,
                FirstName = "NonExistent",
                LastName = "Contact",
                PhoneNumber = "0000000000",
                Address = "Nowhere"
            };

            var result = controller.UpdateContact(updateContact);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Update Contact has failed", badRequestResult.Value);
        }
        [Fact]
        public void DeleteContact_ShouldReturnOkResult_WhenContactExists()
        {
        
            var controller = new ContactsController();
            int contactId = 1; 

            var result = controller.DeleteContact(contactId);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Contact has been deleted", okResult.Value);
        }

        [Fact]
        public void DeleteContact_ShouldReturnBadRequest_WhenContactDoesNotExist()
        {
          
            var controller = new ContactsController();
            int nonExistentContactId = 999; 

            var result = controller.DeleteContact(nonExistentContactId);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Contact has not been deleted", badRequestResult.Value);
        }

    }


}
