using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using backend_api_vertical.Data;
using backend_api_vertical.Domain;
using backend_api_vertical.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_api_vertical.Features.Games.GetGame
{
    public class GetGameHandler
    {
        internal sealed class Handler : IRequestHandler<GameQueryObject, PageList<GetGameResponse>>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            private readonly GetGameSortProperty _sortProperty;

            public Handler(ApplicationDbContext dbContext, IMapper mapper, GetGameSortProperty sortProperty)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                _sortProperty = sortProperty;
            }

            public async Task<PageList<GetGameResponse>> Handle(GameQueryObject request, CancellationToken cancellationToken)
            {
                IQueryable<Game> query = _dbContext.Games;

                if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                {
                    query = query.Where(res => res.Publisher.Contains(request.SearchTerm)
                                 || res.Name.Contains(request.SearchTerm));
                }

                var sortExpression = _sortProperty.GetSortProperty(request);
                if (request.SortOrder.ToLower() == "desc")
                {
                    query = query.OrderByDescending(sortExpression);
                }
                else
                {
                    query = query.OrderBy(sortExpression);
                }


                var queryResponse = query.Select(p => new GetGameResponse()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Publisher = p.Publisher,
                });

                var data = await PageList<GetGameResponse>.CreateAsync(queryResponse, request.Page, request.PageSize, request.Pagination);

                var result = _mapper.Map<PageList<GetGameResponse>>(data);

                return result;




            }
        }
    }
}