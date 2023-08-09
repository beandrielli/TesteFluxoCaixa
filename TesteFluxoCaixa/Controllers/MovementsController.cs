using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using TesteFluxoCaixa.Domain.Entity;
using TesteFluxoCaixa.Domain.Command;
using TesteFluxoCaixa.Domain.Models;

namespace TesteFluxoCaixa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovementsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MovementsController(IMediator mediator) { 
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> Create(MovementRequest request)
        {
            try
            {
                if (request == null || request.Valor <= 0)
                    return BadRequest("Request inválido. Necessário informar um valor maior que 0.");

                if (! Enum.IsDefined(typeof(Shared.MoveType), request.Tipo))
                    return BadRequest("Request Inválido. Tipo de movimentação inválida.");

                MoveCreateCommand command = new MoveCreateCommand() {
                    Move = new Move() {
                        Id = 0,
                        Date = DateTime.Now,
                        Type = (Shared.MoveType)request.Tipo,
                        Value = request.Valor
                    }
                };

                int id = await _mediator.Send(command);
                

                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Consolidado")]
        public async Task<IActionResult> Summary(MovementSummaryRequestCommand requestCommand) {
            try
            {
                if(requestCommand == null || requestCommand.Date == DateTime.MinValue)
                    return BadRequest("Request Inválido.");

                MovementSummaryResponseCommand response = await _mediator.Send(requestCommand);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
