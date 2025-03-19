using System.ComponentModel.DataAnnotations;

namespace TaskManagmentSystem.API.Contracts.MyTasks
{
	public record UpdateMyTaskRequest(
		[Required] string Name,
		[Required] string Description,
		[Required] string Status);
}
