using System.Collections.Generic;
using System.Web;

namespace Enviando_Arquivos_Mvc.Models
{
    public class Remessa
    {
        public IEnumerable<HttpPostedFileBase> Arquivos { get; set; }
    }
}