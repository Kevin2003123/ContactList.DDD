using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DDD.Domain.ValueObjects
{
    public record ContactLastName
    {
        public string Value { get; set; }
        internal ContactLastName(string value)
        {
            this.Value = value;
        }
        public static ContactLastName Create(string value)
        {
            return new ContactLastName(value);
        }
    }
}
