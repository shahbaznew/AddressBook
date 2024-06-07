using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Services
{
    public class ContactService
    {
        private static List<Contact> contacts = new List<Contact>()
        {
            new Contact() { Id = 1, FirstName = "Barry", LastName = "Long", PhoneNumber = "07986543154", Address = "1 Main Street",},
            new Contact() { Id = 2, FirstName = "Paul", LastName = "Liv", PhoneNumber = "07164823571", Address = "2 Main Street",},
            new Contact() { Id = 3, FirstName = "Smith", LastName = "Hudson", PhoneNumber = "07496558217", Address = "3 Main Street",}
        };
        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

        public Contact GetContactID(int id)
        {
            var contact = contacts.FirstOrDefault(contact => contact.Id == id);
            
            return contact;
        }

        public Contact CreateContact(Contact newContact)
        {
            var contact = new Contact();
            contact.Id = newContact.Id;
            contact.FirstName = newContact.FirstName;
            contact.LastName = newContact.LastName;
            contact.PhoneNumber = newContact.PhoneNumber;
            contact.Address = newContact.Address;
            contacts.Add(contact);

            return contact;
        }

        public Contact UpdateContact(Contact updateContact)
        {
            var contact = contacts.FirstOrDefault(contact => contact.Id == updateContact.Id);
            if (contact != null)
            {
                contact.FirstName = updateContact.FirstName;
                contact.LastName = updateContact.LastName;
                contact.PhoneNumber = updateContact.PhoneNumber;
                contact.Address = updateContact.Address;

                return contact;
            }

            return null;
        }

        public Boolean DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(contact => contact.Id == id);
            if (contact == null)
            {
                return false;
            }
            contacts.Remove(contact);
            return true;
        }
    }
}
