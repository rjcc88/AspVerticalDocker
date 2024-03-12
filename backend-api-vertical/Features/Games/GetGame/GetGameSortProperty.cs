using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backend_api_vertical.Domain;

namespace backend_api_vertical.Features.Games.GetGame
{
    public class GetGameSortProperty
    {
        public Expression<Func<Game, object>> GetSortProperty(GameQueryObject request) =>
              request.SortColumn.ToLower() switch
              {
                  "name" => game => game.Name,
                  "publisher" => game => game.Publisher,
                  _ => game => game.Id
              };
    }
}