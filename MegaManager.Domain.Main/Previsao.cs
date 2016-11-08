using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaManager.Domain.Main
{
    public class Previsao : Resultado
    {
        public MegaManager.Models.Enum.MetodoPrevisao ModeloPrevisao { get; set; }
        public string Observacoes { get; set; }

    }
}
