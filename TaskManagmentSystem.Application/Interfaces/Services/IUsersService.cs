using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Models;

namespace TaskManagmentSystem.Application.Interfaces.Services
{
    public interface IUsersService
    {
        Task Register(string email, string userName, string passwordHash);
        Task<string> Login(string username, string password);
        Task<User> GetUserByEmail(string email);
    }
}
