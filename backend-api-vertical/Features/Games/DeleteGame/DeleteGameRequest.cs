using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace backend_api_vertical.Features.Games.DeleteGame
{
    public class DeleteGameRequest : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public DeleteGameRequest(Guid id)
        {
            Id = id;
        }
    }
}