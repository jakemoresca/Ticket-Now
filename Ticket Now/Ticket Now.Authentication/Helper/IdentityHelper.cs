using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Ticket_Now.Authentication.Helper
{
    public class IdentityHelper
    {
        public static string GetUserNameFromClaims(IEnumerable<Claim> claims)
        {
            return GetClaim("sub", claims);
        }

        public static string GetClaim(string type, IEnumerable<Claim> claims)
        { 
            foreach (var claim in claims)
            {
                if (claim.Type == type)
                    return claim.Value;
            }

            throw new Exception("No claim found for type: " + type);
        }
    }
}