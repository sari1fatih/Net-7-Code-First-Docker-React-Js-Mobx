using Common.Classes.Wrappers;
using RealEstate.Application.Features.Entity.Tools.Dtos;

namespace RealEstate.Application.Interfaces.Application.Features.Entity
{
    public interface IEntityManager
	{
        Task<Response<IEnumerable<EntityDto>>> GetList();
    }
}

