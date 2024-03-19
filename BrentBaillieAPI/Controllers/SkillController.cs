using BrentBaillieAPI.Models;
using BrentBaillieAPI.Services.Skills;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrentBaillieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService infoService)
        {
            _skillService = infoService;
        }

        // GETALLL api/Skill
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var skill = await _skillService.GetAllAsync();
            return Ok(skill);
        }

        // GET api/SkillController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var skill = await _skillService.GetById(id);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }

        // POST api/SkillController
        [HttpPost]
        public async Task<IActionResult> Post(Skill skill)
        {
            await _skillService.CreateAsync(skill);
            return Ok("Created");
        }

        // PUT api/SkillController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Skill newSkill)
        {
            var skill = await _skillService.GetById(id);
            if (skill == null)
            {
                return NotFound();
            }
            await _skillService.UpdateAsync(id, newSkill);
            return Ok("Updated");
        }

        // DELETE api/SkillControlle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var skill = await _skillService.GetById(id);
            if (skill == null)
            {
                return NotFound();
            }
            await _skillService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
