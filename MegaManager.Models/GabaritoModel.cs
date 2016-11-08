using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaManager.Models
{
    public class GabaritoModel : BaseModel
    {
        
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Observacoes { get; set; }

        /// <summary>
        /// Número do gabarito
        /// </summary>
        public int Numero { get; set; }


        /// <summary>
        /// De 1 - 9
        /// </summary>
        public int Quantidade1 { get; set; }


        /// <summary>
        /// 10 - 19
        /// </summary>
        public int Quantidade2 { get; set; }


        /// <summary>
        /// 20 - 29
        /// </summary>
        public int Quantidade3 { get; set; }

        /// <summary>
        /// 30 - 39
        /// </summary>
        public int Quantidade4 { get; set; }

        /// <summary>
        /// 40 a 49
        /// </summary>
        public int Quantidade5 { get; set; }

        /// <summary>
        /// 50 a 59
        /// </summary>
        public int Quantidade6 { get; set; }


        /// <summary>
        /// 60
        /// </summary>
        public int Quantidade7 { get; set; }

        


    }
}
