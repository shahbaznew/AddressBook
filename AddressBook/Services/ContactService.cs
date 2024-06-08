using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Services
{
    public class ContactService : IContactService
    {
        private readonly string _filePath;

        public ContactService()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "contacts.json");

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }
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
