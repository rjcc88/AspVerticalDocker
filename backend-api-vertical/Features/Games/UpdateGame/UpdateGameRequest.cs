using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace backend_api_vertical.Features.Games.UpdateGame
{
    public class UpdateGameRequest : IRequest<UpdateGameResponse>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Publisher { get; set; }
    }
}