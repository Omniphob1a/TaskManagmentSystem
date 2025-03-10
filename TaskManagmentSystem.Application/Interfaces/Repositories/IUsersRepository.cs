using System;
using TaskManagmentSystem.Core.Enums;
using TaskManagmentSystem.Core.Models;

namespace TaskManagmentSystem.Application.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
        Task<HashSet<Permission>> GetUserPermissions(Guid userId);
    }
}
