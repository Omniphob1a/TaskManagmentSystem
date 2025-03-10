using Microsoft.AspNetCore.Authorization;
using TaskManagmentSystem.Core.Enums;

namespace LearninPlatform.Infrastructure.Authentication;

public class PermissionRequirement(Permission[] permissions)
    : IAuthorizationRequirement
{
    public Permission[] Permissions { get; set; } = permissions;
}