using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using AddressBook.Controllers;
using AddressBook.Models;
using System.Collections.Generic;
using AddressBook.Services;

namespace AddressBook.Tests.Controllers
{
    public class ContactsControllerTests
    {
        private readonly Mock<IContactService> _mockContactService;
        private readonly ContactsController _controller;

        public ContactsControllerTests()
        {
            _mockContactService = new Mock<IContactService>();

            _controller = new ContactsController(_mockContactService.Object);
        }
        [Fact]
        public void GetAllContacts_ShouldReturnOkResultWithContacts()
        {
            var contacts = new List<Contact>
            {
                new Contact { Id = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "1234567890", Address = "1 Main Street", Email = "JohnDoe@gmail.com"},
                new Contact { Id = 2, FirstName = "Barry", LastName = "Long", PhoneNumber = "0987654321", Address = "2 Main Street", Email = "BarryLong@gmail.com" },
                new Contact { Id = 3, FirstName = "Alice", LastName = "Smith", PhoneNumber = "9876543210", Address = "3 Main Street" , Email = "AliceSmith@gmail.com"}
            };
            _mockContactService.Setup(service => service.GetAllContacts()).Returns(contacts);

            var result = _controller.AllContacts();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Contact>>(okResult.Value);
            Assert.Equal(3, returnValue.Count);
        }

        [Fact]
        public void GetID_ShouldReturnOkResultWithContact_WhenContactExists()
        {
            var contact = new Contact { Id = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "1234567890", Address = "1 Main Street", Email = "JohnDoe@gmail.com"};
            _mockContactService.Setup(service => service.GetContactID(1)).Returns(contact);

            var result = _controller.GetID(1);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(contact.Id, returnValue.Id);
        }

        [Fact]
        public void GetID_ShouldReturnBadRequest_WhenContactDoesNotExist()
        {
            _mockContactService.Setup(service => service.GetContactID(1)).Returns((Contact)null);

            var result = _controller.GetID(1);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Contact is not found", badRequestResult.Value);
        }
        [Fact]
        public void CreateContact_ShouldReturnOkResultWithNewContact()
        {
            var newContact = new Contact { FirstName = "New", LastName = "Contact", PhoneNumber = "1231231234", Address = "123 Apple Street", Email = "newcontact@gmail.com"};
            var createdContact = new Contact { Id = 3, FirstName = "New", LastName = "Contact", PhoneNumber = "1231231234", Address = "123 Apple Street", Email = "newcontact@gmail.com"};
            _mockContactService.Setup(service => service.CreateContact(newContact)).Returns(createdContact);

            var result = _controller.CreateContact(newContact);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(createdContact.Id, returnValue.Id);
        }
        [Fact]
        public void CreateContact_ShouldReturnBadRequest_WhenCreationFails()
        {
            var newContact = new Contact { FirstName = "New", LastName = "Contact", PhoneNumber = "1231231234", Address = "123 Apple Street", Email = "newcontact@gmail.com"};
            _mockContactService.Setup(service => service.CreateContact(newContact)).Returns((Contact)null);

            var result = _controller.CreateContact(newContact);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Update Contact has failed", badRequestResult.Value);
        }
        [Fact]
        public void UpdateContact_ShouldReturnOkResultWithUpdatedContact_WhenContactExists()
        {
            var updateContact = new Contact { Id = 1, FirstName = "Updated", LastName = "Name", PhoneNumber = "11122333457", Address = "Updated Address", Email = "newcontact@gmail.com"};
            _mockContactService.Setup(service => service.UpdateContact(updateContact)).Returns(updateContact);

            var result = _controller.UpdateContact(updateContact);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(updateContact.FirstName, returnValue.FirstName);
        }

        [Fact]
        public void UpdateContact_ShouldReturnBadRequest_WhenUpdateFails()
        {
            var updateContact = new Contact { Id = 1, FirstName = "Updated", LastName = "Name", PhoneNumber = "11122333457", Address = "Updated Address", Email = "newcontact@gmail.com" };
            _mockContactService.Setup(service => service.UpdateContact(updateContact)).Returns((Contact)null);

            var result = _controller.UpdateContact(updateContact);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Update Contact has failed", badRequestResult.Value);
        }
        [Fact]
        public void DeleteContact_ShouldReturnOkResult_WhenContactExists()
        {
            _mockContactService.Setup(service => service.DeleteContact(1)).Returns(true);

            var result = _controller.DeleteContact(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Contact has been deleted", okResult.Value);
        }

        [Fact]
        public void DeleteContact_ShouldReturnBadRequest_WhenContactDoesNotExist()
        {
            _mockContactService.Setup(service => service.DeleteContact(1)).Returns(false);

            var result = _controller.DeleteContact(1);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Contact has not been deleted", badRequestResult.Value);
        }

    }


}
