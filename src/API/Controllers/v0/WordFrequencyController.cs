using API.Filters.ValidationModels;
using Test;
using Test.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.v0
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v{version:apiVersion}/wordfrequency")]
    public class WordFrequencyController : ControllerBase
    {
        private readonly IWordFrequencyAnalyzer _wordFrequencyAnalyzer;

        public WordFrequencyController(IWordFrequencyAnalyzer wordFrequencyAnalyzer)
        {
            _wordFrequencyAnalyzer = wordFrequencyAnalyzer;
        }


        [HttpPost]
        [Route("calculate-highest-frequency")]
        [Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully response CalculateHighestFrequency")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ValidationErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CalculateHighestFrequency([FromBody] HighestFrequencyWordRequest highestFrequencyWordRequest)
        {
            var result = await _wordFrequencyAnalyzer.CalculateHighestFrequencyAsync(highestFrequencyWordRequest.Text);
            return Ok(result);
        }

        [HttpPost]
        [Route("calculate-frequency-for-word")]
        [Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully response CalculateFrequencyForWord")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ValidationErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CalculateFrequencyForWord([FromBody] FrequencyForWordRequest calculateFrequencyForWordRequest)
        {
            var result = await _wordFrequencyAnalyzer.CalculateFrequencyForWordAsync(calculateFrequencyForWordRequest.Text, calculateFrequencyForWordRequest.Word);
            return Ok(result);
        }

        [HttpPost]
        [Route("calculate-mostfrequent-nwords")]
        [Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully response CalculateMostFrequentNWords")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ValidationErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CalculateMostFrequentNWords([FromBody] MostFrequentNWordsRequest mostFrequentNWordsRequest)
        {
            var result = await _wordFrequencyAnalyzer.CalculateMostFrequentNWordsAsync(mostFrequentNWordsRequest.Text,mostFrequentNWordsRequest.MostFrequentMaxWordCount);
            return Ok(result);
        }

    }
}
