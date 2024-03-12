using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace backend_api_vertical.Features.Games.CreateGame
{
    public class CreateGameRequest : IRequest<CreateGameResponse>
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
    }
}