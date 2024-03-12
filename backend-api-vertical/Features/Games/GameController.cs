using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Asp.Versioning;
using backend_api_vertical.Features.Games.CreateGame;
using backend_api_vertical.Features.Games.DeleteGame;
using backend_api_vertical.Features.Games.GetGame;
using backend_api_vertical.Features.Games.GetGameById;
using backend_api_vertical.Features.Games.UpdateGame;
using backend_api_vertical.Shared;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace backend_api_vertical.Features.Games
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/game")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Create([FromBody] CreateGameRequest request)
        {
            var res = await _mediator.Send(request);

            if (res == null)
            {
                return BadRequest();
            }
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllGame([FromQuery] GameQueryObject query)
        {
            var res = await _mediator.Send(query);
            if (res.Equals(null))
            {
                return NotFound("No games found");
            }
            return Ok(res);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdateGame(UpdateGameRequest request)
        {
            var res = await _mediator.Send(request);
            if (res == null)
            {
                return StatusCode(404, "The game with the given id does not exist" + request.Id);
            }

            return Ok(res);
        }


        [HttpGet("{id:Guid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> GetGame([FromRoute] Guid id)
        {
            var res = await _mediator.Send(new GetGameByIdRequest(id));
            if (res == null)
            {
                return StatusCode(404, "The game with the given id does not exist" + id);
            }

            return Ok(res);
        }

        [HttpDelete("{id:Guid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> DeleteGame([FromRoute] Guid id)
        {
            var res = await _mediator.Send(new DeleteGameRequest(id));
            return Ok(res);
        }

    }
}
