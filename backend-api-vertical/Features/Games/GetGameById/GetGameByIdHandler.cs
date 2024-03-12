using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend_api_vertical.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace backend_api_vertical.Features.Games.GetGameById
{
    public class GetGameByIdHandler : IRequestHandler<GetGameByIdRequest, GetGameByIdResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGameByIdHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<GetGameByIdResponse> Handle(GetGameByIdRequest request, CancellationToken cancellationToken)
        {
            var query = await _dbContext.Games.FirstOrDefaultAsync(res => res.Id == request.Id, cancellationToken);
            var result = _mapper.Map<GetGameByIdResponse>(query);
            return result;
        }

    }
}