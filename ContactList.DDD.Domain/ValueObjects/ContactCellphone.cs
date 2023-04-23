using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DDD.Domain.ValueObjects
{
    public record ContactCellphone
    {
        public string Value { get; set; }
        internal ContactCellphone(string value)
        {
            this.Value = value;
        }
        public static ContactCellphone Create(string value)
        {
            return new ContactCellphone(value);
        }
    }
}
