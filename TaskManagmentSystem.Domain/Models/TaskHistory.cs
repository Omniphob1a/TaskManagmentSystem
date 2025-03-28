using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Domain.Entities;

namespace TaskManagmentSystem.Domain.Models
{
	public class TaskHistory
	{
		private TaskHistory(
			Guid id,
			string fieldName,
			string oldValue,
			string newValue,
			DateTime? changeDate,
			Guid changedByUserId,
			Guid taskId
			)
		{
			Id = id;
			FieldName = fieldName;
			OldValue = oldValue;
			NewValue = newValue;
			ChangeDate = changeDate;
			ChangedByUserId = changedByUserId;
			TaskId = taskId;
		}

		public Guid Id { get; set; }
		public string FieldName { get; set; }
		public string OldValue { get; set; }
		public string NewValue { get; set; }
		public DateTime? ChangeDate { get; set; }
		public Guid ChangedByUserId { get; set; }
		public Guid TaskId { get; set; }
		public static TaskHistory Create(
			Guid id,
			string fieldName,
			string oldValue,
			string newValue,
			DateTime? changeDate,
			Guid changedByUserId,
			Guid taskId	)
		{
			if (string.IsNullOrEmpty(fieldName))
				throw new ArgumentException("FieldName cannot be null!");

			if (string.IsNullOrEmpty(oldValue))
				throw new ArgumentException("OldValue cannot be null!");

			if (string.IsNullOrEmpty(newValue))
				throw new ArgumentException("NewValue cannot be null!");

			if (changeDate == null)
				throw new ArgumentException("ChangeData cannot be null!");

			return new TaskHistory(id, fieldName, oldValue, newValue, changeDate, changedByUserId, taskId);
		}
	}
}
