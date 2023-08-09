using MediatR;
using TesteFluxoCaixa.Domain.Command;
using TesteFluxoCaixa.Domain.Entity;
using TesteFluxoCaixa.Repository;

namespace TesteFluxoCaixa.Domain.Handler
{
    public class MovementCreateHandler : IRequestHandler<MoveCreateCommand, int>
    {

        private readonly IMediator _mediator;
        private readonly IRepository<Move> _repository;

        public MovementCreateHandler(IMediator mediator, IRepository<Move> repository) { 
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<int> Handle(MoveCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int id = await _repository.Add(request.Move);

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error trying to create movement: " + ex.Message);
            }
        }
    }
}
