using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Interfaces.Application.Features.Entity;

namespace RealEstate.WebAPI.Controllers.Entity
{
    [Route("api/[controller]")]
    public class EntityController : Persistence.ControllerBase.ControllerBase
    {
        private readonly IEntityManager _entityManager;
        public EntityController(IEntityManager entityManager)
        {
            _entityManager = entityManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _entityManager.GetList());
        }
    }
}
