using Evolent.DataAccessLayer.Services;
using Evolent.Models.ContactModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EvolentContactTest
{
    public static class DBContextExtension
    {
        public static void Seed(this ContactDataAccess contact)
        {
            
            GetContactJson(contact);
           
            contact.SaveChanges();
        }

         static void GetContactJson(ContactDataAccess contact)
        {
            using (StreamReader r = new StreamReader(@"C:\Chandan\Assignment\EvolentHealth_old\EvolentContactTest\Contacts.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<Contact>>(json);
                foreach (var item in items)
                {
                    contact.Add(item);
                }
            }

        }
    }
}
