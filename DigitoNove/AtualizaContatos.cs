using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace DigitoNove
{
    class AtualizaContatos
    {
        public async void SelecionaContatos()
        {
            var agenda = await ContactManager.RequestStoreAsync();
            var contatos = await agenda.FindContactsAsync();           

            var fones = contatos.Where(c => c.Phones.Count > 0).SelectMany(c => c.Phones).Select(p => p.Number);

            Regex r = new Regex(@"(\+55\d{2}|\+55\s\d{2}\s|0\d{2}|0\d{2}\s|)([6-9]\d{3})(-|\s|)(\d{4})");

            foreach (var fone in fones)
            {
                var match = r.Match(fone);
                if (match.Success)
                {
                    var gp1 = match.Groups[1];
                    var gp2 = match.Groups[2];
                    var gp3 = match.Groups[3];
                    var gp4 = match.Groups[4];

                    var prefixado = "9" + gp2.Value;
                    var foneFinal = gp1.Value + prefixado + gp3.Value + gp4.Value;
                    Debug.WriteLine(foneFinal);
                                        
                }
            }                               
        }
    }
}
