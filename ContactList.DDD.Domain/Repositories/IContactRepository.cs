using ContactList.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DDD.Domain.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int id);
        Task<Boolean> InsertContact(Contact contact);
        Task<Boolean> DeleteContact(int id);
        Task<Boolean> UpdateContact(Contact contact);
        Task<IEnumerable<Contact>> GetContactsPerPage(int PageNumber, string Order, string OrderBy);
        Task<IEnumerable<Contact>> SearchContactsPerPage(int PageNumber, string SearchTerm, string Order, string OrderBy);
    }
}
