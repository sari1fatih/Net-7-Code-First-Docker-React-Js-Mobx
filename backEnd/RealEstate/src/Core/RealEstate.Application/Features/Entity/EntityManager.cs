using AutoMapper;
using Common.Classes.Exceptions;
using Common.Classes.Wrappers;
using RealEstate.Application.Features.Entity.Tools.Constraints;
using RealEstate.Application.Features.Entity.Tools.Dtos;
using RealEstate.Application.Interfaces.Application.Features.Entity;
using RealEstate.Application.Interfaces.Persistence.Repositories;

namespace RealEstate.Application.Features.Entity
{
    public class EntityManager : IEntityManager
    {
        private readonly IEntityRepositoryAsync _entityRepositoryAsync;
        protected IMapper _mapper;
        public EntityManager(IEntityRepositoryAsync entityRepositoryAsync, IMapper mapper)
        {
            _entityRepositoryAsync = entityRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<EntityDto>>> GetList()
        {
            var entity = await _entityRepositoryAsync.GetAllAsync();
            if (entity == null) throw new ApiException(EntityConstraint.EntityNotFound);
            var entityDto = _mapper.Map<IEnumerable<EntityDto>>(entity); 
            return new Response<IEnumerable<EntityDto>>(entityDto);
        }
    }
}

