using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaManager.Models
{
    public class ResultadoModel : BaseModel
    {
        public string Concurso { get; set; }

        public string Dezena1 { get; set; }
        public string Dezena2 { get; set; }
        public string Dezena3 { get; set; }
        public string Dezena4 { get; set; }
        public string Dezena5 { get; set; }
        public string Dezena6 { get; set; }

        public string DataSorteio { get; set; }
        
        public int Gabarito { get; set; }


        public int Soma
        {
            get
            {
                return int.Parse(Dezena1) + int.Parse(Dezena2) + int.Parse(Dezena3) + int.Parse(Dezena4) + int.Parse(Dezena5) + int.Parse(Dezena6);
            }
        }
        
        public int DiferencaSomaAnteior { get; set; }


        private string _Tipo;
        public string Tipo
        {

            get
            {
                lock (this)
                {
                    IdentificaTipo();
                }
                return _Tipo;

            }
            private set
            {
                _Tipo = value;
            }
        }


        private void IdentificaTipo()
        {
            _Tipo = string.Empty;

            var dezenas = new List<string> { Dezena1, Dezena2, Dezena3, Dezena4, Dezena5, Dezena6 };

            var qtd1 = dezenas.Count(x => int.Parse(x) < 10);
            var qtd2 = dezenas.Count(x => int.Parse(x) > 9 && int.Parse(x) < 20);
            var qtd3 = dezenas.Count(x => int.Parse(x) > 19 && int.Parse(x) < 30);
            var qtd4 = dezenas.Count(x => int.Parse(x) > 29 && int.Parse(x) < 40);
            var qtd5 = dezenas.Count(x => int.Parse(x) > 39 && int.Parse(x) < 50);
            var qtd6 = dezenas.Count(x => int.Parse(x) > 49 && int.Parse(x) < 60);
            var qtd7 = dezenas.Count(x => int.Parse(x) > 59 && int.Parse(x) < 70);

            int qtd = 0;

            for (int i = 1; i < 8; i++)
            {
                switch (i)
                {

                    case 1:
                        qtd = qtd1;
                        break;

                    case 2:
                        qtd = qtd2;
                        break;

                    case 3:
                        qtd = qtd3;
                        break;

                    case 4:
                        qtd = qtd4;
                        break;

                    case 5:
                        qtd = qtd5;
                        break;

                    case 6:
                        qtd = qtd6;
                        break;

                    case 7:
                        qtd = qtd7;
                        break;

                    default:
                        break;
                }



                switch (qtd)
                {
                    case 0:
                    case 1:
                        continue;

                    case 2:
                        _Tipo = 'P' + _Tipo;
                        break;

                    case 3:
                        _Tipo = 'T' + _Tipo;
                        break;

                    case 4:
                        _Tipo = 'Q' + _Tipo;
                        break;

                    case 5:
                        _Tipo = 'V' + _Tipo;
                        break;

                    case 6:
                        _Tipo = 'S' + _Tipo;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("erro");

                }
            }
            
            if (string.IsNullOrEmpty(_Tipo))
                Tipo = _Tipo + 'U';

        }

        public int QuantidadePares
        {
            get
            {
                var dezenas = new List<int> { 
                    int.Parse(Dezena1), 
                    int.Parse(Dezena2), 
                    int.Parse(Dezena3), 
                    int.Parse(Dezena4), 
                    int.Parse(Dezena5), 
                    int.Parse(Dezena6) };

                var output = dezenas.Count(x => x % 2 == 0);

                return output;
            }
        }

        public int QuantidadeImpares {
            get {
                var dezenas = new List<int> { int.Parse(Dezena1), 
                                                int.Parse(Dezena2), 
                                                int.Parse(Dezena3), 
                                                int.Parse(Dezena4), 
                                                int.Parse(Dezena5), 
                                                int.Parse(Dezena6)};

                var output = dezenas.Count(x => x % 2 != 0);

                return output;
            }
        }






    }
}
