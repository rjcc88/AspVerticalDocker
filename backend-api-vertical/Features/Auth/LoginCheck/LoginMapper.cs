using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend_api_vertical.Domain.Entities;

namespace backend_api_vertical.Features.Auth.LoginCheck
{
    public class LoginMapper : Profile
    {
        public LoginMapper()
        {
            CreateMap<LoginRequest, User>();
            CreateMap<User, LoginResponse>();
        }
    }
}