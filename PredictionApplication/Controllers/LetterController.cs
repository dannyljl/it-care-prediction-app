using Microsoft.AspNetCore.Mvc;
using PredictionApplication.Enums;
using PredictionApplication.Extensions;
using PredictionApplication.Factories;
using PredictionApplication.Models;
using PredictionApplication.Services;

namespace PredictionApplication.Controllers
{
    [ApiController]
    [Route("letter")]
    public class LetterController : Controller
    {
        private readonly ILogger<LetterController> _logger;

        public LetterController(ILogger<LetterController> logger)
        {
            _logger = logger;
        }

        [HttpPost("sicknesstype")]
        public IActionResult Post(SicknessType sicknessType, [FromBody] Client client)
        {
            if(client.DateOfBirth.Age() < 14)
            {
                return BadRequest("client age is under 14, age:" + client.DateOfBirth.Age());
            }
            if (String.IsNullOrEmpty(client.Address))
            {
                return BadRequest("address is not valid, address:" + client.Address);
            }
            try
            {
                ILetterService _letterService = new LetterService(SicknessTypePredictorFactory.PredictorFromType(sicknessType));

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
