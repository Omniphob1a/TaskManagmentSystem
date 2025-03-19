using TaskManagmentSystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentSystem.Domain.Models
{
    public class MyTask
    {
        private MyTask(
            Guid id,
            string name,
            string description,
            string status)
        {
            Id = id;
            Name = name; 
            Description = description; 
            Status = status;
        }
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? Status { get; private set; }
		public static MyTask Create(Guid id, string name, string description, string status)
		{
			if (string.IsNullOrEmpty(name)) throw new ArgumentException("Title cannot be null!");

			if (string.IsNullOrEmpty(description)) throw new ArgumentException("Description cannot be null!");

			if (string.IsNullOrEmpty(status)) throw new ArgumentException("Status cannot be null!");

			return new MyTask(id, name, description, status);
		}
	}
}
