using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ProHub.Domain.Dtos.Jwt;

namespace ProHub.Domain.Services.Jwt
{
    public interface IJwtServices
    {
        TokenDto GenerateEncodedToken(string userId, string email, IEnumerable<Claim> additionalClaims = null);

    }
}
