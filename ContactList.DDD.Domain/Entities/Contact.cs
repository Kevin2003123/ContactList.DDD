using ContactList.DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DDD.Domain.Entities
{
    public class Contact
    {
        public int Id { get; init; }
        public ContactName Name { get;  set; }
        public ContactLastName LastName { get; set; }
        public ContactCellphone Cellphone { get; set; }
        public ContactEmail Email { get;  set; }
        public DateTime dateOfRegistration { get; init; }


        //public Contact(int id, DateTime date) { this.Id = id; this.dateOfRegistration = date; }
        

        public void SetName(ContactName name) { Name = name; }
        public void SetLastName(ContactLastName lastName) { LastName = lastName; }
        public void SetCellphone(ContactCellphone cellphone) { Cellphone = cellphone; } 
        public void SetEmail(ContactEmail email) { Email = email; }
    }
}
