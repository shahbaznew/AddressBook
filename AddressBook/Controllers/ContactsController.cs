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
            var service = new ContactService();
            var contact = service.GetContactID(id);
            if (contact == null)
            {
                return BadRequest("Contact is not found"); 
            }
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] Contact newContact)
        {
            var service = new ContactService();

            var contact = service.CreateContact(newContact);
            if (contact == null)
            {
                return BadRequest("Update Contact has failed");
            }

            return Ok(contact);
        }

        [HttpPut]
        public IActionResult UpdateContact([FromBody] Contact updateContact)
        {
            var service = new ContactService();
            var contact = service.UpdateContact(updateContact);
            if (contact == null)
            {
                return BadRequest("Update Contact has failed");
            }
            return Ok(contact);
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var service = new ContactService();
            var result = service.DeleteContact(id);
            if (result == false)
            {
                return BadRequest("Contact has not been deleted");
            }
          
            return Ok("Contact has been deleted");
        }
    }
}
