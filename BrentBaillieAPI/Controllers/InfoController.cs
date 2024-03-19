using BrentBaillieAPI.Models;
using BrentBaillieAPI.Services.Information;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrentBaillieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IInfoService _infoService;
        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        // GETALLL api/Info
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var info = await _infoService.GetAllAsync();
            return Ok(info);
        }

        // GET api/InfoController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var info = await _infoService.GetById(id);
            if (info == null)
            {               
                return NotFound();
            }
            return Ok(info);
        }

        // POST api/InfoController
        [HttpPost]
        public async Task<IActionResult> Post(Info info)
        {
            await _infoService.CreateAsync(info);
            return Ok("Created");
        }

        // PUT api/InfoController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Info newInfo)
        {
            var info = await _infoService.GetById(id);
            if (info == null)
            {
                return NotFound();
            }
            await _infoService.UpdateAsync(id, newInfo);
            return Ok("Updated");
        }

        // DELETE api/InfoControlle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var info = await _infoService.GetById(id);
            if (info == null)
            {
                return NotFound();
            }
            await _infoService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
