using MediatR;
using TesteFluxoCaixa.Domain.Command;
using TesteFluxoCaixa.Domain.Entity;
using TesteFluxoCaixa.Repository;

namespace TesteFluxoCaixa.Domain.Handler
{
    public class MovementSummaryHandler : IRequestHandler<MovementSummaryRequestCommand, MovementSummaryResponseCommand>
    {

        private readonly IMediator _mediator;
        private readonly IRepository<Move> _repository;

        public MovementSummaryHandler(IMediator mediator, IRepository<Move> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<MovementSummaryResponseCommand> Handle(MovementSummaryRequestCommand request, CancellationToken cancellationToken)
        {
            MovementSummaryResponseCommand movement = new MovementSummaryResponseCommand();

            try
            {
                movement.Moves = await _repository.GetSummary(request.Date);
                movement.Total = (
                    movement.Moves.Where(_move => _move.Type == Shared.MoveType.Credit).Sum(_move => _move.Value) -
                    movement.Moves.Where(_move => _move.Type == Shared.MoveType.Debit).Sum(_move => _move.Value)
                );
                movement.Date = request.Date;

                return movement;
            }
            catch (Exception ex)
            {
                throw new Exception("Error trying to get movement summary: " + ex.Message);
            }
        }
    }
}
