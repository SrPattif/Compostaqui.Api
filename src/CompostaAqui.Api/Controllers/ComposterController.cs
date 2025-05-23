﻿using CompostaAqui.Api.Extensions;
using CompostaAqui.Application.Interfaces;
using CompostaAqui.Application.Models.Composter;
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
            return result.Ok();
        }

        [HttpGet("{uuid}")]
        public async Task<IActionResult> Get(Guid uuid)
        {
            var result = await _service.GetByGuidAsync(uuid);
            return result.Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComposterPostModel model)
        {
            var result = await _service.CreateAsync(model);
            return result.Ok();
        }

        [HttpPut("{uuid}")]
        public async Task<IActionResult> Put(Guid uuid, [FromBody] ComposterPutModel model)
        {
            var result = await _service.UpdateAsync(uuid, model);
            return result.Ok();
        }

        [HttpDelete("{uuid}")]
        public async Task<IActionResult> Delete(Guid uuid)
        {
            var result = await _service.DeleteAsync(uuid);
            return result.NoContent();
        }
    }
}
