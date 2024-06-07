using AddressBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<ContactsController>
        [HttpGet]
        public IActionResult AllContacts()
        {
            return Ok(contacts);
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public string GetID(int id)
        {
            return "value";
        }

        // POST api/<ContactsController>
        [HttpPost]
        public void CreateContact([FromBody] string value)
        {
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public void UpdateContact(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
