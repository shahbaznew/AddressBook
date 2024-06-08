using Newtonsoft.Json;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Xml;

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
        private List<Contact> LoadContacts()
        {
            var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Contact>>(jsonData) ?? new List<Contact>();
        }
        private void SaveContacts(List<Contact> contacts)
        {
            var jsonData = JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
        public List<Contact> GetAllContacts()
        {
            return LoadContacts();
        }

        public Contact GetContactID(int id)
        {
            var contacts = LoadContacts(); 
            var contact = contacts.FirstOrDefault(contact => contact.Id == id);

            return contact;
        }

        public Contact CreateContact(Contact newContact)
        {
            var contacts = LoadContacts();
            newContact.Id = contacts.Any() ? contacts.Max(c => c.Id) + 1 : 1;
            contacts.Add(newContact);
            SaveContacts(contacts);
            return newContact;
        }

        public Contact UpdateContact(Contact updateContact)
        {
            var contacts = LoadContacts();
            var contact = contacts.FirstOrDefault(contact => contact.Id == updateContact.Id);
            if (contact != null)
            {
                contact.FirstName = updateContact.FirstName;
                contact.LastName = updateContact.LastName;
                contact.PhoneNumber = updateContact.PhoneNumber;
                contact.Address = updateContact.Address;
                SaveContacts(contacts);
                return contact;
            }

            return null;
        }

        public Boolean DeleteContact(int id)
        {
            var contacts = LoadContacts();
            var contact = contacts.FirstOrDefault(contact => contact.Id == id);
            if (contact != null)
            {
                contacts.Remove(contact);
                SaveContacts(contacts);
                return true;
            }
            return false;
        }
    }
}
