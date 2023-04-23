using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DDD.Domain.ValueObjects
{
    public record ContactName
    {
        public string Value { get; set; }
        internal ContactName(string value)
        {
            this.Value = value;
        }
        public static ContactName Create(string value)
        {
            return new ContactName(value);
        }
    }
}
