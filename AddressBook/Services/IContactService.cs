using AddressBook.Models;

namespace AddressBook.Services
{
    public interface IContactService
    {
        Contact CreateContact(Contact newContact);
        bool DeleteContact(int id);
        List<Contact> GetAllContacts();
        Contact GetContactID(int id);
        Contact UpdateContact(Contact updateContact);
    }
}