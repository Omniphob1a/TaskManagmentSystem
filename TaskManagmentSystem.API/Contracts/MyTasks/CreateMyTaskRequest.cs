using System.ComponentModel.DataAnnotations;

namespace TaskManagmentSystem.API.Contracts.MyTasks
{
	public record CreateMyTaskRequest(
		[Required] string Name,
		[Required] string Description,
		[Required] string Status);
}
