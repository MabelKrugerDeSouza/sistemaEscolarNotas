namespace sistemaEscolarNotas.Domain.Entities
{
    public class ProvaEntity : BaseEntity
    {
        public string DescricaoQuestao { get; set; }
        public int QuantasMultiEscolhas { get; set; }
        public string DescricaoMultiEscolha { get; set; }
        public int QuantasQuestoes { get; set; }
        public double PontosQuestoes { get; set; }
        public double Nota { get; set; }
        public double Media { get; set; }
    }
}
