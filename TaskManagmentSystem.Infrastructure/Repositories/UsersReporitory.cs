using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Enums;
using TaskManagmentSystem.Application.Interfaces.Repositories;
using TaskManagmentSystem.Core.Domain.Entities;
using TaskManagmentSystem.Core.Models;
using TaskManagmentSystem.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace TaskManagmentSystem.Infrastructure.Repositories
{
    public class UsersReporitory : IUsersRepository
    {
        private readonly TaskManagmentSystemContext _context;
        private readonly IMapper _mapper;
        public UsersReporitory(TaskManagmentSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(User user)
        {
            var roleEntity = await _context.Roles
            .SingleOrDefaultAsync(r => r.Id == (int)Role.User)
            ?? throw new InvalidOperationException();

            var userEntity = new UserEntity()
            {
                Id = user.Id,
                Username = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                Roles = [roleEntity]
            };

            await _context.Users.AddAsync(userEntity);
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users.
                AsNoTracking()
                .FirstOrDefaultAsync(r => r.Email == email);

            return _mapper.Map<User>(userEntity);
        }

        public Task<HashSet<Permission>> GetUserPermissions(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
