using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend_api_vertical.Domain;

namespace backend_api_vertical.Features.Games.CreateGame
{
    public class CreateGameMapper : Profile
    {
        public CreateGameMapper()
        {
            CreateMap<CreateGameRequest, Game>();
            CreateMap<Game, CreateGameResponse>();
        }
    }
}