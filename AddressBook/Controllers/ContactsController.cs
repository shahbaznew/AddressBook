using AddressBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace AddressBook.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static List<Contact> contacts = new List<Contact>()
        {
            new Contact() { Id = 1, FirstName = "Barry", LastName = "Long", PhoneNumber = "07986543154", Address = "1 Main Street",},
            new Contact() { Id = 2, FirstName = "Paul", LastName = "Liv", PhoneNumber = "07164823571", Address = "2 Main Street",},
            new Contact() { Id = 3, FirstName = "Smith", LastName = "Hudson", PhoneNumber = "07496558217", Address = "3 Main Street",}
        };
        [HttpGet]
        public IActionResult AllContacts()
        {
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {
            var contact = contacts.FirstOrDefault(contact => contact.Id == id);
            if (contact == null)
            {
                return BadRequest("Contact is not found"); 
            }
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] string value)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] string value)
        {
            return null; 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return null; 
        }
    }
}
