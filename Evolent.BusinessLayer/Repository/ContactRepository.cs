using Evolent.BusinessLayer.Interface;
using Evolent.DataAccessLayer.Services;
using Evolent.Models.ContactModel;
using Evolent.Models.DBModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.BusinessLayer.Repository
{
    public class ContactRepository : IContact
    {
        private ContactDataAccess _dataObject;
        private IOptions<Settings> _settings;

        //public ContactRepository(IOptions<Settings> settings, IConfiguration configuration)
        //{
        //    _settings = settings;
        //    _dataObject = new ContactDataAccess(settings, configuration);
        //}

        public ContactRepository(ContactDataAccess context)
        {
            _dataObject = context;
        }
        public async Task<bool> Add(Contact contact)
        {
            if(contact.Id==0)
            {
                _dataObject.Add<Contact>(contact);
            }
            else
            {
                Contact c = _dataObject.Contact.Where(x => x.Id == contact.Id).FirstOrDefault();
                c.FirstName = contact.FirstName;
                c.LastName = contact.LastName;
                c.Email = contact.Email;
                c.PhoneNumber = contact.PhoneNumber;
                c.Status = contact.Status;
                _dataObject.Entry<Contact>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            int i = await _dataObject.SaveChangesAsync();
            if (i == 1) return true; else return false;
        }
        public async Task<bool> Delete(int Id)
        {
            Contact c = _dataObject.Contact.Where(x => x.Id == Id).FirstOrDefault();
            
            c.Status =Enum.GetName(typeof(Status), Status.Inactive);
            _dataObject.Entry<Contact>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            int i = await _dataObject.SaveChangesAsync();
            if (i == 1) return true; else return false;

        }
        public async Task<IEnumerable<Contact>> Get()
        {
            await Task.Delay(10);
            return _dataObject.Contact.ToList();
        }
    }
}
