using AppData.Entities;
using AppData.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XeThueController : ControllerBase
    {
        private readonly IXeThueRepository _xeThueRepository;
        private readonly IValidator<XeThue> _xeThueValidator;

        public XeThueController(IXeThueRepository xeThueRepository, IValidator<XeThue> xeThueValidator)
        {
            _xeThueRepository = xeThueRepository;
            _xeThueValidator = xeThueValidator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<XeThue>>> GetAll()
        {
            var xeThueList = await _xeThueRepository.GetAllXeThueAsync();
            return Ok(xeThueList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<XeThue>> GetById(Guid id)
        {
            var xeThue = await _xeThueRepository.GetXeThueByIdAsync(id);
            if (xeThue == null)
            {
                return NotFound();
            }
            return Ok(xeThue);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] XeThue xeThue)
        {
            var validationResult = await _xeThueValidator.ValidateAsync(xeThue);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => new
                {
                    field = e.PropertyName,
                    message = e.ErrorMessage
                }));
            }

            await _xeThueRepository.AddXeThueAsync(xeThue);
            return CreatedAtAction(nameof(GetById), new { id = xeThue.ID }, xeThue);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] XeThue xeThue)
        {
            if (id != xeThue.ID)
            {
                return BadRequest();
            }

            var validationResult = await _xeThueValidator.ValidateAsync(xeThue);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => new
                {
                    field = e.PropertyName,
                    message = e.ErrorMessage
                }));
            }

            await _xeThueRepository.UpdateXeThueAsync(xeThue);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var xeThue = await _xeThueRepository.GetXeThueByIdAsync(id);
            if (xeThue == null)
            {
                return NotFound();
            }

            await _xeThueRepository.DeleteXeThueAsync(xeThue);
            return NoContent();
        }

        [HttpGet("TinhChiPhiThueXe")]
        public async Task<ActionResult<decimal>> TinhChiPhiThueXe(Guid id, DateTime ngayThue, DateTime ngayTra)
        {
            try
            {
                var chiPhi = await _xeThueRepository.TinhChiPhiThueXeAsync(id, ngayThue, ngayTra);
                return Ok(chiPhi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
