namespace TaskManagmentSystem.Core.Domain.Entities
{
    public class MyTaskEntity
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? Status { get; private set; }
        public UserEntity? User { get; private set; }
        public Guid UserId { get; private set; }
        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Name cannot be empty");
            Name = newName;
        }
        public void ChangeDescription(string newDescription)
        {
            Description = newDescription;
        }
    }
    
}
