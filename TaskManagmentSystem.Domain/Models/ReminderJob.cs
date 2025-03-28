using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Application.Interfaces.Models;

namespace TaskManagmentSystem.Domain.Models
{
	public class ReminderJob
	{
		public Guid TaskId { get; init; }
		public string UserEmail { get; init; }
		public string Message { get; init; }
		public string TaskName { get; set; }
		public string TaskDescription { get; set; }
	}

}
