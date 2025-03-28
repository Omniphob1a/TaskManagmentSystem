using System;
using TaskManagmentSystem.Domain.Entities;
namespace TaskManagmentSystem.Core.Domain.Entities;
    public class UserEntity 
    { 
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
	    public string PasswordHash { get; set; } = string.Empty;
	    public string Email { get; set; } = string.Empty;
	    public ICollection<RoleEntity> Roles { get; set; } = [];
        public List<TaskHistoryEntity> TaskHistories { get; set; } = [];
}   

