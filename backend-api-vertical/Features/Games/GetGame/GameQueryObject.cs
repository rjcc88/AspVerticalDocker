using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api_vertical.Shared;
using MediatR;

namespace backend_api_vertical.Features.Games.GetGame
{
    public class GameQueryObject : IRequest<PageList<GetGameResponse>>
    {
        public string SortOrder { get; set; } = string.Empty;
        public string SortColumn { get; set; } = string.Empty;

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 30;

        public string? SearchTerm { get; set; }

        public bool Pagination { get; set; } = false;
    }
}