using TaskManagmentSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Application.Interfaces.Auth;
using TaskManagmentSystem.Application.Interfaces.Repositories;
using TaskManagmentSystem.Application.Interfaces.Services;
using LearningPlatform.Application.Auth;

namespace TaskManagmentSystem.Application.Services
{

    public class UsersService : IUsersService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtProvider _jwtProvider;
        public UsersService(IPasswordHasher passwordHasher, IUsersRepository usersRepository, IJwtProvider jwtProvider)
        {
            _passwordHasher = passwordHasher;
            _usersRepository = usersRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.Generate(user);

            return token;
        }

        public async Task Register(string email, string userName, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            var user = User.Create(Guid.NewGuid(), userName, hashedPassword, email);
            await _usersRepository.Add(user);
        }
		public async Task<User?> GetUserByEmail(string email)
		{
			return await _usersRepository.GetByEmail(email);
		}
	}
}
