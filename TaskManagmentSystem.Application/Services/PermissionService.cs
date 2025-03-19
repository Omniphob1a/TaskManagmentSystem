using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Application.Interfaces.Repositories;
using TaskManagmentSystem.Application.Interfaces.Services;
using TaskManagmentSystem.Core.Enums;

namespace TaskManagmentSystem.Application.Services
{
	public class PermissionService : IPermissionService
	{
		private readonly IUsersRepository _usersRepository;

		public PermissionService(IUsersRepository usersRepository)
		{
			_usersRepository = usersRepository;
		}

		public Task<HashSet<Permission>> GetPermissionsAsync(Guid userId)
		{
			return _usersRepository.GetUserPermissions(userId);
		}
	}
}
