using BrentBaillieAPI.Models;
using BrentBaillieAPI.Services.WorkIntance;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrentBaillieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkInstanceController : ControllerBase
    {
        private readonly IWorkInstanceService _workInstanceService;
        public WorkInstanceController(IWorkInstanceService workInstanceService)
        {
            _workInstanceService = workInstanceService;
        }

        // GETALLL api/WorkInstance
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workInstances = await _workInstanceService.GetAllAsync();
            return Ok(workInstances);
        }

        // GET api/WorkInstanceController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var workInstance = await _workInstanceService.GetById(id);
            if (workInstance == null)
            {
                return NotFound();
            }
            return Ok(workInstance);
        }

        // POST api/WorkInstanceController
        [HttpPost]
        public async Task<IActionResult> Post(WorkInstance workInstance)
        {
            await _workInstanceService.CreateAsync(workInstance);
            return Ok("Created");
        }

        // PUT api/WorkInstanceController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] WorkInstance newWorkInstance)
        {
            var workInstance = await _workInstanceService.GetById(id);
            if (workInstance == null)
            {
                return NotFound();
            }
            await _workInstanceService.UpdateAsync(id, newWorkInstance);
            return Ok("Updated");
        }

        // DELETE api/WorkInstanceControlle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var workInstance = await _workInstanceService.GetById(id);
            if (workInstance == null)
            {
                return NotFound();
            }
            await _workInstanceService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
