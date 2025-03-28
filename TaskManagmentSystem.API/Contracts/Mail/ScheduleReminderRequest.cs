using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentSystem.Domain.Models
{
	public record ScheduleReminderRequest(
		[Required][EmailAddress] string UserEmail,
		[Required] string CronExpression,
		string? Message = null);
}
