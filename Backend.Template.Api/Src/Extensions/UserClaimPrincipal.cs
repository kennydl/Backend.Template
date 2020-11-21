using System;
using System.Security.Claims;
using Backend.Template.Api.Models;

namespace Backend.Template.Api.Extensions
{
    public static class UserClaimPrincipal
    {
        public static Guid GetObjectId(this ClaimsPrincipal principal)
        {
            var claim = principal.FindFirst(ClaimKeys.ObjectId);
            return Guid.TryParse(claim?.Value, out var oid) ? oid : Guid.Empty;
        }
    }
}