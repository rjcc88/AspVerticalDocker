using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api_vertical.Features.Auth.Register
{
    public class RegisterResponse
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}