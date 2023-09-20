using Microsoft.AspNetCore.Mvc;
using TurniketWebApi.Service.DTOs.RegistrationDTOs;
using TurniketWebApi.Service.IServices;

namespace TurniketWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService registrationService;
        public RegistrationController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
          Ok(await registrationService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll() =>
           Ok(await registrationService.GetAllAsync());

        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] RegistrationForCreationDTO registrationForCreation) =>
           Ok(await registrationService.CreateAsync(registrationForCreation));

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery] int id,
                   [FromBody] RegistrationForCreationDTO registrationForCreation) =>
          Ok(await registrationService.UpdateAsync(id, registrationForCreation));

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> Delete([FromRoute] int id) =>
          Ok(await registrationService.DeleteAsync(id));
    }
}
