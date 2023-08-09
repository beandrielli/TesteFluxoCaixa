using MediatR;
using TesteFluxoCaixa.Domain.Entity;

namespace TesteFluxoCaixa.Domain.Command
{
    public class MovementSummaryRequestCommand : IRequest<MovementSummaryResponseCommand>
    {
        public DateTime Date { get; set; }

    }
}
