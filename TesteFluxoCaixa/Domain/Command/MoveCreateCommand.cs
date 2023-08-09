using MediatR;
using TesteFluxoCaixa.Domain.Entity;

namespace TesteFluxoCaixa.Domain.Command
{
    public class MoveCreateCommand : IRequest<int>
    {
        public Move Move { get; set; }

    }
}
