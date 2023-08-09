using TesteFluxoCaixa.Domain.Entity;

namespace TesteFluxoCaixa.Domain.Command
{
    public class MovementSummaryResponseCommand
    {
        public List<Move> Moves { get; set; }

        public Decimal Total { get; set; }

        public DateTime Date { get; set; }
    }
}
