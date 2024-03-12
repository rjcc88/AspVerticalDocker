using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend_api_vertical.Data;
using backend_api_vertical.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace backend_api_vertical.Features.Games.UpdateGame
{
    public class UpdateGameHandler
    {

        public class UpdateGame : IRequestHandler<UpdateGameRequest, UpdateGameResponse>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            public UpdateGame(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<UpdateGameResponse> Handle(UpdateGameRequest request, CancellationToken cancellationToken)
            {
                var queryId = await _dbContext.Games.FirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new KeyNotFoundException("The game with the given id does not exist");
                var result = _mapper.Map<Game>(queryId);
                _dbContext.Entry(result).CurrentValues.SetValues(request);
                var res = await _dbContext.SaveChangesAsync(cancellationToken);
                var updateRes = _mapper.Map<UpdateGameResponse>(result);
                return updateRes;
            }
        }
    }
}