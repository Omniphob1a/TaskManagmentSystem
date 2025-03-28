using System.ComponentModel.DataAnnotations;

namespace TaskManagmentSystem.API.Contracts.MyTasks
{
	public class GetMyTaskResponse(
		Guid Id,
		string Name,
		string Description,
		string Status);
}
