using AutoMapper;
using TaskManagmentSystem.Core.Models;
using TaskManagmentSystem.Core.Domain.Entities;
using TaskManagmentSystem.Domain.Models;
using TaskManagmentSystem.Domain.Entities;

namespace LearningPlatform.Persistence.Mappings;
public class DataBaseMappings : Profile
{
    public DataBaseMappings()
    {
        CreateMap<UserEntity, User>();
		CreateMap<MyTaskEntity, MyTask>();
        CreateMap<TaskHistoryEntity, TaskHistory>();
	}
}