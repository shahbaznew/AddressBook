using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Tests.ServiceTests
{
    public class ContactServiceTests
    {
         private readonly string _testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "test_contacts.json");

        public ContactServiceTests()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
            File.WriteAllText(_testFilePath, "[]");
        }
    }
}
