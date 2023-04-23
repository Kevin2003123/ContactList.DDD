using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DDD.Domain.ValueObjects
{
    public record ContactDateOfRegistration
    {
        public DateTime value { get; init; }
        internal ContactDateOfRegistration(DateTime value_) { value = value_; }

        public static ContactDateOfRegistration Create(DateTime value) { return new ContactDateOfRegistration(value); }
        public static implicit operator DateTime(ContactDateOfRegistration contactDateOfRegistration) { return contactDateOfRegistration.value; }
    }
}
