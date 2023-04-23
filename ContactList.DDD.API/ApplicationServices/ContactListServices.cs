using ContactList.DDD.Domain.Repositories;
using ContactList.DDD.Domain.Entities;
using ContactList.DDD.API.Commands;

namespace ContactList.DDD.API.ApplicationServices
{
    public class ContactListServices
    {

        private readonly IContactRepository repository;
        public ContactListServices(IContactRepository repository)
        {
            this.repository = repository;
        }

        public async Task HandleCommand(InsertContactCommand createContact)
        {

        }
    }
}
