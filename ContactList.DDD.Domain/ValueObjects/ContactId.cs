using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DDD.Domain.ValueObjects
{
    public record ContactId
    {
        public int value { get; init; }
        internal ContactId( int value_) { value = value_; }

        public static ContactId Create(int value) { return new ContactId(value); }
        public static implicit operator int(ContactId contactId) { return contactId.value; }
    }
}
