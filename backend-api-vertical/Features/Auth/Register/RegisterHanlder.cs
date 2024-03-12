using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using backend_api_vertical.Data;
using backend_api_vertical.Domain.Entities;
using backend_api_vertical.Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend_api_vertical.Features.Auth.Register
{
    public class RegisterHanlder
    {
        public class Handler : IRequestHandler<RegisterRequest, RegisterResponse>
        {
            private readonly UserManager<User> _userManager;
            private readonly ITokenService _tokenService;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, UserManager<User> userManager, ITokenService tokenService)
            {
                _userManager = userManager;
                _tokenService = tokenService;
                _mapper = mapper;
            }

            public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
            {
                try
                {
                    var appUser = new User
                    {
                        UserName = request.UserName,
                        Email = request.Email
                    };

                    var createdUser = await _userManager.CreateAsync(appUser, request.Password);

                    if (createdUser.Succeeded)
                    {
                        var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                        if (roleResult.Succeeded)
                        {
                            var result = _mapper.Map<RegisterResponse>(new RegisterResponse
                            {
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = _tokenService.CreateToken(appUser)

                            });
                            return result;
                        }
                        else
                        {
                            throw null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (System.Exception)
                {
                    throw;
                }

            }
        }
    }
}