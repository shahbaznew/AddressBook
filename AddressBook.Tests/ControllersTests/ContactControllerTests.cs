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
    }
}
