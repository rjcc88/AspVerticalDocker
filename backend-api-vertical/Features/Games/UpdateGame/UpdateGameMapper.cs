using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend_api_vertical.Domain;

namespace backend_api_vertical.Features.Games.UpdateGame
{
    public class UpdateGameMapper : Profile
    {
        public UpdateGameMapper()
        {
            CreateMap<UpdateGameRequest, Game>();
            CreateMap<Game, UpdateGameResponse>();
        }
    }
}