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
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService) 
        {
            _contactService = contactService;
        }
       
        [HttpGet]
        public IActionResult AllContacts()
        {
           
            return Ok(_contactService.GetAllContacts());
        }

        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {
            var contact = _contactService.GetContactID(id);
            if (contact == null)
            {
                return BadRequest("Contact is not found"); 
            }
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] Contact newContact)
        {

            var contact = _contactService.CreateContact(newContact);
            if (contact == null)
            {
                return BadRequest("Update Contact has failed");
            }

            return Ok(contact);
        }

        [HttpPut]
        public IActionResult UpdateContact([FromBody] Contact updateContact)
        {
            var contact = _contactService.UpdateContact(updateContact);
            if (contact == null)
            {
                return BadRequest("Update Contact has failed");
            }
            return Ok(contact);
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var result = _contactService.DeleteContact(id);
            if (result == false)
            {
                return BadRequest("Contact has not been deleted");
            }
          
            return Ok("Contact has been deleted");
        }
    }
}
