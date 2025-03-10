using AutoMapper;
using TaskManagmentSystem.Core.Models;
using TaskManagmentSystem.Core.Domain.Entities;

namespace LearningPlatform.Persistence.Mappings;
public class DataBaseMappings : Profile
{
    public DataBaseMappings()
    {
        CreateMap<UserEntity, User>();
    }
}