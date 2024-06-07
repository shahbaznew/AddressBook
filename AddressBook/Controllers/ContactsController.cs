using AddressBook.Models;
using AddressBook.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace AddressBook.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult AllContacts()
        {
            var service = new ContactService();
            return Ok(service.GetAllContacts());
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
        public IActionResult CreateContact([FromBody] Contact newContact)
        {
            var contact = new Contact();
            contact.Id = newContact.Id;
            contact.FirstName = newContact.FirstName;
            contact.LastName = newContact.LastName;
            contact.PhoneNumber = newContact.PhoneNumber;
            contact.Address = newContact.Address;
            contacts.Add(contact);

            return Ok(contact);
        }

        [HttpPut]
        public IActionResult UpdateContact([FromBody] Contact updateContact)
        {
            var contact = contacts.FirstOrDefault(contact => contact.Id == updateContact.Id);
            if (contact == null)
            {
                return BadRequest("Update Contact has failed");
            }

            contact.FirstName = updateContact.FirstName;
            contact.LastName = updateContact.LastName;
            contact.PhoneNumber = updateContact.PhoneNumber;
            contact.Address = updateContact.Address;

            return Ok(contact);
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(contact => contact.Id == id);
            if (contact == null)
            {
                return BadRequest("Contact has not been deleted");
            }
            contacts.Remove(contact); 
            return Ok("Contact has been deleted");
        }
    }
}
