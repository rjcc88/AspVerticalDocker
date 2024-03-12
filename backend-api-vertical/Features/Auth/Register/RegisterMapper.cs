using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend_api_vertical.Domain.Entities;

namespace backend_api_vertical.Features.Auth.Register
{
    public class RegisterMapper : Profile
    {
        public RegisterMapper()
        {
            CreateMap<RegisterRequest, User>();
            CreateMap<User, RegisterResponse>();
        }
    }
}