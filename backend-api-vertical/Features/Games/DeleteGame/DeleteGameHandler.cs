using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend_api_vertical.Data;
using MediatR;

namespace backend_api_vertical.Features.Games.DeleteGame
{
    public class DeleteGameHandler
    {
        public class Handler : IRequestHandler<DeleteGameRequest, Guid>
        {
            private readonly ApplicationDbContext _dbContext;
            public Handler(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Guid> Handle(DeleteGameRequest request, CancellationToken cancellationToken)
            {
                var game = _dbContext.Games.FindAsync(request.Id).Result;
                if (game == null)
                    throw new KeyNotFoundException("Game not found");

                _dbContext.Games.Remove(game);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return request.Id;
            }
        }
    }
}
