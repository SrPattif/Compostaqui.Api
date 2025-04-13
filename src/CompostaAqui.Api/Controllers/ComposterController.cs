using CompostaAqui.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompostaAqui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComposterController : ControllerBase
    {
        private readonly IComposterService _service;

        public ComposterController(IComposterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}
