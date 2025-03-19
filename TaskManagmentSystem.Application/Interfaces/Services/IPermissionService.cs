using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Enums;

namespace TaskManagmentSystem.Application.Interfaces.Services
{
	public interface IPermissionService
	{
		Task<HashSet<Permission>> GetPermissionsAsync(Guid userId);
	}
}
