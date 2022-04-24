using Microsoft.AspNetCore.Authorization;
using RoadSystemControl.Domains.Enums;

namespace RoadSystemControl.Admin.Api.Core;

public class AuthorizeRoleAttribute : AuthorizeAttribute
{
    public AuthorizeRoleAttribute(params UserRole[] roles)
    {
        Roles = string.Join(",", roles);
    }
}