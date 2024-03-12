using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace backend_api_vertical.Features.Auth.LoginCheck
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}