using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend_api_vertical.Data;
using backend_api_vertical.Domain;
using backend_api_vertical.Shared;
using FluentValidation;
using MediatR;

namespace backend_api_vertical.Features.Games.CreateGame
{
    public class CreateGameHandler
    {
        public class Handler : IRequestHandler<CreateGameRequest, CreateGameResponse>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            private readonly IValidator<CreateGameRequest> _validator;
            public Handler(ApplicationDbContext dbContext, IMapper mapper, IValidator<CreateGameRequest> validator)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                _validator = validator;
            }
            public async Task<CreateGameResponse> Handle(CreateGameRequest request, CancellationToken cancellationToken)
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return (CreateGameResponse)Results.ValidationProblem(validationResult.ToDictionary());
                }
                var gameModel = _mapper.Map<Game>(request);

                _dbContext.Games.Add(gameModel);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var result = _mapper.Map<CreateGameResponse>(gameModel);
                return result;
            }
        }
    }
}