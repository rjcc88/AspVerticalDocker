using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api_vertical.Domain.Entities;

namespace backend_api_vertical.Domain.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}