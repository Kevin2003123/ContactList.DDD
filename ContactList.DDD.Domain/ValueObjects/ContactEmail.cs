using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DDD.Domain.ValueObjects
{
    public record ContactEmail
    {
        public string Value { get; set; }
        internal ContactEmail(string value)
        {
            this.Value = value;
        }
        public static ContactEmail Create(string value)
        {
            return new ContactEmail(value);
        }
    }
}
