namespace MegaManager.Domain.Main
{
    public class Previsao : Resultado
    {
        public Models.Enum.MetodoPrevisao ModeloPrevisao { get; set; }
        public string Observacoes { get; set; }

    }
}
