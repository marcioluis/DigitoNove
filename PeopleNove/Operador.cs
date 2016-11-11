using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace PeopleNove
{
    public class Operador
    {

        public async static Task<List<Contact>> GetContacts()
        {
            //http://stackoverflow.com/questions/34138113/office-365-unified-api-returns-only-10-contacts
            var graph = AuthenticationHelper.GetAuthenticatedClient();
            var contatcs = graph.Me.Contacts.Request();
            var lista = await contatcs.GetAsync();
            return lista.ToList();
        }

    }
}
