using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentSystem.Application.Interfaces.Services
{
    public interface IUsersService
    {
        public Task Register(string email, string userName, string passwordHash);
        public Task<string> Login(string username, string password);
    }
}
