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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMessageOfTheDayByDay(string day)
        {
            if (string.IsNullOrEmpty(day))
                return BadRequest();

            var model = await _service.GetMessageByDay(day);

            if (model == null || model.Message == "")
                return BadRequest();

            return Ok(model);
        }

        // GET api/<EDaysController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
