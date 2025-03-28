using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentSystem.Application.Interfaces.Models
{
	public interface IMessage
	{
		string ToEmail { get; }
		string Subject { get; } 
		string Body { get; }
		List<IFormFile>? Attachments { get; } 
	}
}
