using System;

namespace MegaManager.Models
{

    public static class Enum
    {

        [Flags]
        public enum TipoGabarito
        {
            /// <summary>
            /// Par de uma cor
            /// </summary>
            P = 0x0, 
            
            /// <summary>
            /// Dois pares de cores distintas
            /// </summary>
            PP = 0x1,

            /// <summary>
            /// Três pares de cores distinta
            /// </summary>
            PPP = 0x2,

            /// <summary>
            /// Quadra de uma cor
            /// </summary>
            Q = 0x4,

            /// <summary>
            /// Quadra de uma cor e par de outra
            /// </summary>
            QP = 0x8,

            /// <summary>
            /// Seis números de uma cor
            /// </summary>
            S = 0x10,
            
            /// <summary>
            /// Trinca de uma cor
            /// </summary>
            T = 0x11,

            /// <summary>
            /// Trinca de uma cor e par de outra
            /// </summary>
            TP = 0x12,

            /// <summary>
            /// Duas trincas de cores distintas
            /// </summary>
            TT = 0x13,

            /// <summary>
            /// Unitário (nenhuma cor repetida)
            /// </summary>
            U = 0x14,

            /// <summary>
            /// Quina de mesma cor
            /// </summary>
            V = 0x15,
        }

        public enum MetodoPrevisao {
            Nenhum = 0x0,
            NaivePolinomial = 0x1,
            LinearModel = 0x2,
            MarkovChain = 0x3
        }
    }
}
