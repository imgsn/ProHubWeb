using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ProHub.Core.Dtos.Jwt;

namespace ProHub.Core.Services.Jwt
{
    public interface IJwtServices
    {
        TokenDto GenerateEncodedToken(string userId, string email, IEnumerable<Claim> additionalClaims = null);

    }
}
