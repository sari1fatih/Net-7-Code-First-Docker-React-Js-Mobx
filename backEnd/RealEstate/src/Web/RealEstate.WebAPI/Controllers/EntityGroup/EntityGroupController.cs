using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Interfaces.Application.Features.EntityGroup;

namespace RealEstate.WebAPI.Controllers.EntityGroup
{
    [Route("api/[controller]")]
    public class EntityGroupController : Persistence.ControllerBase.ControllerBase
    {
        private readonly IEntityGroupManager _entityGroupManager;
        public EntityGroupController(IEntityGroupManager entityGroupManager)
        {
            _entityGroupManager = entityGroupManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _entityGroupManager.GetList());
        }
    }
}
