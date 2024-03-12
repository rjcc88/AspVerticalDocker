using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend_api_vertical.Domain.Entities;
using backend_api_vertical.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend_api_vertical.Features.Auth.LoginCheck
{
    public class LoginHandler
    {
        public class Handler : IRequestHandler<LoginRequest, LoginResponse>
        {
            private readonly UserManager<User> _userManager;
            private readonly ITokenService _tokenService;
            private readonly IMapper _mapper;
            private readonly SignInManager<User> _signInManager;

            public Handler(IMapper mapper, UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
            {
                _userManager = userManager;
                _tokenService = tokenService;
                _signInManager = signInManager;
                _mapper = mapper;
            }

            public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
            {
                var userAuth = _mapper.Map<User>(request);
                var userQuery = await _userManager.Users.FirstOrDefaultAsync(res => res.UserName == userAuth.UserName.ToLower()) ?? throw new UnauthorizedAccessException("Inavlid username!");
                var resultAuth = await _signInManager.CheckPasswordSignInAsync(userQuery, request.Password, false);
                if (!resultAuth.Succeeded) throw new UnauthorizedAccessException("Invalid Username and password!");

                var result = _mapper.Map<LoginResponse>(new LoginResponse
                {
                    Token = _tokenService.CreateToken(userQuery)
                });

                return result;


            }
        }
    }
}