using HL.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HL.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("create")]
        public Task<IActionResult> Post([FromBody] GameNewRequestNew model)
        {
            var response = _mediator.Send(model);
            return response;
        }

        [HttpGet("{id}/players")]
        public Task<IActionResult> GetPlayers(int id)
        {
            var request = new PlayerGameByGameId { GameId = id };
            var response = _mediator.Send(request);
            return response;
        }

        [HttpPost("{id}/answer")]
        public Task<IActionResult> Post(int id, [FromBody] StepAnswerNewRequest model)
        {
            model.GameId = id;
            var response = _mediator.Send(model);
            return response;
        }

        [HttpGet("{id}/score")]
        public Task<IActionResult> GetScore(int id)
        {
            var request = new GameScoreRequest { Id = id };
            var response = _mediator.Send(request);
            return response;
        }

    }
}