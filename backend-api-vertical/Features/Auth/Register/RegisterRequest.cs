using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace backend_api_vertical.Features.Auth.Register
{
    public class RegisterRequest : IRequest<RegisterResponse>
    {
        [Required]
        public string? UserName { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}