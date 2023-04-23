using System.Xml.Linq;

namespace ContactList.DDD.API.Commands
{
    public record InsertContactCommand(string Name, string LastName,string Cellphone, string Email);
              
}
