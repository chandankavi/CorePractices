using Evolent.Models.ContactModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.BusinessLayer.Interface
{
    public interface IContact
    {
        Task<bool> Add(Contact contact);
        Task<IEnumerable<Contact>> Get();
        Task<bool> Delete(int Id);
    }
}
