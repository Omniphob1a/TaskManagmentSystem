using TaskManagmentSystem.Domain.Entities;

namespace TaskManagmentSystem.Core.Domain.Entities
{
    public class MyTaskEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Status { get; set; } = string.Empty;
        public List<TaskHistoryEntity> TaskHistories { get; set; } = [];
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
