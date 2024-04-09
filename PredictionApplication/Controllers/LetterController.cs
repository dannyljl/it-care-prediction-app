using Microsoft.AspNetCore.Mvc;
using PredictionApplication.Enums;
using PredictionApplication.Models;
using PredictionApplication.Services;

namespace PredictionApplication.Controllers
{
    [ApiController]
    [Route("letter")]
    public class LetterController : Controller
    {
        private readonly ILogger<LetterController> _logger;
        private readonly ILetterService _letterService;

        public LetterController(ILogger<LetterController> logger, ILetterService letterService)
        {
            _logger = logger;
            _letterService = letterService;
        }

        [HttpPost("sicknesstype")]
        public IActionResult Get(SicknessType sicknessType, [FromBody] Client client)
        {
            try
            {
                return Ok(_letterService.CreateLetter(client, sicknessType));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
