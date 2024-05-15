using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recommender.Client.DTOs;
using Recommender.Services;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;

namespace Recommender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        private readonly IOpenAIService _openAIService;

        public OpenAIController(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            try
            {
                var result = await _openAIService.CompleteSentence("Once upon a time");
                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return ($"Error: {ex.Message}");
            } 
        }

        [HttpPost]
        public async Task<string> Post(PromptDTO request)
        {
            try
            {
                var result = await _openAIService.CompleteSentence(request.Prompt);
                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return ($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("advanced")]
        public async Task<string> AdvancedPost(PromptDTO request)
        {
            try
            {
                var result = await _openAIService.CompleteSentenceAdvanced(request.Prompt);
                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return ($"Error: {ex.Message}");
            }
        }
    }
}