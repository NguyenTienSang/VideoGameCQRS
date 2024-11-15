using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCQRS.Data;
using VideoGameCQRS.Features.Players.CreatePlayer;
using VideoGameCQRS.Features.Players.GetPlayerById;
using VideoGameCQRS.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace VideoGameCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        //private readonly VideoGameAppDbContext _context;
        private readonly ISender _sender;

        public PlayersController(VideoGameAppDbContext context, ISender sender)
        {
            //_context = context;
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePlayer(CreatePlayerCommand command)
        {
            var playerId = await _sender.Send(command);

            return Ok(playerId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _sender.Send(new GetPlayerIdQuery(id));

            if(player is null)
            {
                return NotFound();
            }

            return Ok(player);
        }
    }
}
