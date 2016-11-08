using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaManager.Domain.Main
{
    public class Loteria
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        
        public string UrlDownloadResultados { get; set; }
        public string UrlDownloadCookieresultados { get; set; }

    }
}
