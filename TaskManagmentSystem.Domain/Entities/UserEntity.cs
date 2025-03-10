using System;
namespace TaskManagmentSystem.Core.Domain.Entities;
    public class UserEntity 
    { 
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public ICollection<RoleEntity> Roles { get; set; } = [];

}

