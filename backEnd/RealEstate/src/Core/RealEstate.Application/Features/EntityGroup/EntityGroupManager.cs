using AutoMapper;
using Common.Classes.Exceptions;
using Common.Classes.Wrappers;
using RealEstate.Application.Features.Entity.Tools.Constraints;
using RealEstate.Application.Features.EntityGroup.Tools.Dtos;
using RealEstate.Application.Interfaces.Application.Features.EntityGroup;
using RealEstate.Application.Interfaces.Persistence.Repositories;

namespace RealEstate.Application.Features.EntityGroup
{
    public class EntityGroupManager : IEntityGroupManager
    {
        private readonly IEntityGroupRepositoryAsync _entityGroupRepositoryAsync;
        protected IMapper _mapper;
        public EntityGroupManager(IEntityGroupRepositoryAsync entityGroupRepositoryAsync, IMapper mapper)
        {
            _entityGroupRepositoryAsync = entityGroupRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<EntityGroupDto>>> GetList()
        {
            var entityGroup = await _entityGroupRepositoryAsync.GetAllWithEntityAsync();
            if (entityGroup == null) throw new ApiException(EntityConstraint.EntityNotFound);
            var entityGroupDto = _mapper.Map<IEnumerable<EntityGroupDto>>(entityGroup);
            return new Response<IEnumerable<EntityGroupDto>>(entityGroupDto);
        }
    }
}

