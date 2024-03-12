using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace backend_api_vertical.Features.Games.GetGameById
{
    public record GetGameByIdRequest(Guid Id) : IRequest<GetGameByIdResponse>;
}