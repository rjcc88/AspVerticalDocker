using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api_vertical.Features.Games.CreateGame
{
    public class CreateGameResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
    }
}