using Common.Classes.Wrappers;
using RealEstate.Application.Features.EntityGroup.Tools.Dtos;

namespace RealEstate.Application.Interfaces.Application.Features.EntityGroup
{
    public interface IEntityGroupManager
    {
        Task<Response<IEnumerable<EntityGroupDto>>> GetList();
    }
}

