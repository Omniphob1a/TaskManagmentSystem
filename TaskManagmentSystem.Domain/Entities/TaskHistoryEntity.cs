using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Domain.Entities;
using TaskManagmentSystem.Core.Models;

namespace TaskManagmentSystem.Domain.Entities
{
	public class TaskHistoryEntity
	{
		public Guid Id { get; set; }
		public string FieldName { get; set; }
		public string OldValue { get; set; }
		public string NewValue { get; set; }
		public MyTaskEntity? Task { get; set; }
		public DateTime? ChangeDate { get; set; }
		public Guid ChangedByUserId { get; set; }
		public Guid TaskId { get; set; }
		public UserEntity? User { get; set; }
	}
}
