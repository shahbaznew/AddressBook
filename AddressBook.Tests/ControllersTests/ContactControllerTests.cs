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
            // Arrange
            var controller = new ContactsController();
            int contactId = 1; // ID of an existing contact

            // Act
            var result = controller.GetID(contactId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var contact = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(contactId, contact.Id);
        }

        [Fact]
        public void GetID_ShouldReturnBadRequest_WhenContactDoesNotExist()
        {
            // Arrange
            var controller = new ContactsController();
            int nonExistentContactId = 999; // ID that does not exist

            // Act
            var result = controller.GetID(nonExistentContactId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Contact is not found", badRequestResult.Value);
        }
    }

    
}
