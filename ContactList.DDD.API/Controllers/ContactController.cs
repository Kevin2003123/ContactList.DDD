
using ContactList.DDD.Domain.Entities;
using ContactList.DDD.Domain.Repositories;
using ContactList.DDD.Infrastructure;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactListApi.Controllers
{


    namespace ContactListApi.Controllers
    {
        [Route("contact")]
        [ApiController]
       

        [HttpGet]
            public List<Contact> Get()
            {
            ContactRepository contactRepo = new ContactRepository();
            return contactRepo.GetAllContacts();
            }

            [HttpGet]
            [Route("page")]
            public List<Contact> Get(int PageNumber, string Order, string OrderBy)
            {
                return _contactRepository.GetContactsPerPage(PageNumber, Order, OrderBy);
            }


            [HttpGet]
            [Route("search")]
            public List<Contact> Get(int PageNumber, string SearchTerm, string Order, string OrderBy)
            {
                return _contactRepository.SearchContactsPerPage(PageNumber, SearchTerm, Order, OrderBy);
            }

            [HttpGet("{id}")]
            public Contact Get(int id)
            {
                return _contactRepository.GetContactById(id);
            }

            [HttpPost]
            public bool Post([FromBody] Contact contact)
            {
                return _contactRepository.InsertContact(contact);
            }

            [HttpPut]
            public bool Put([FromBody] Contact contact)
            {
                return _contactRepository.UpdateContact(contact);
            }

            [HttpDelete("{id}")]
            public bool Delete(int id)
            {
                return _contactRepository.DeleteContact(id);
            }
        }
    }
}