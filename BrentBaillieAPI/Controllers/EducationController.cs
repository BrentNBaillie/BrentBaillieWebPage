using BrentBaillieAPI.Models;
using BrentBaillieAPI.Services.Educations;
using Microsoft.AspNetCore.Mvc;

// For more educationrmation on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrentBaillieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        // GETALLL api/Education
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var education = await _educationService.GetAllAsync();
            return Ok(education);
        }

        // GET api/EducationController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var education = await _educationService.GetById(id);
            if (education == null)
            {
                return NotFound();
            }
            return Ok(education);
        }

        // POST api/EducationController
        [HttpPost]
        public async Task<IActionResult> Post(Education education)
        {
            await _educationService.CreateAsync(education);
            return Ok("Created");
        }

        // PUT api/EducationController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Education newEducation)
        {
            var education = await _educationService.GetById(id);
            if (education == null)
            {
                return NotFound();
            }
            await _educationService.UpdateAsync(id, newEducation);
            return Ok("Updated");
        }

        // DELETE api/EducationControlle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var education = await _educationService.GetById(id);
            if (education == null)
            {
                return NotFound();
            }
            await _educationService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
