using e_Days.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace e_Days.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EDaysController : ControllerBase
    {
        private readonly IEDaysService _service;

        public EDaysController(IEDaysService service)
        {
            _service = service;
        }

        [HttpGet("days/{day}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMessageOfTheDayByDay(string day)
        {
            if (string.IsNullOrEmpty(day))
                return NotFound();

            var model = await _service.GetMessageByDay(day);

            if (model == null || model.Message == "")
                return NotFound();

            return Ok(model);
        }
    }
}
