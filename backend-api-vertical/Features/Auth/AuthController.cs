using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api_vertical.Domain.Entities;
using backend_api_vertical.Domain.Interfaces;
using backend_api_vertical.Features.Auth.LoginCheck;
using backend_api_vertical.Features.Auth.Register;
using backend_api_vertical.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_api_vertical.Features.Auth
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var res = await _mediator.Send(request);

            return Ok(res);

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }
    }
}