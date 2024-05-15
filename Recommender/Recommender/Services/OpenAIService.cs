
using Microsoft.Extensions.Options;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using Recommender.Shared;

namespace Recommender.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly OpenAIConfig _config;
        public OpenAIService(IOptionsMonitor<OpenAIConfig> config) 
        {
            _config = config.CurrentValue;
        }
        public async Task<string> CompleteSentence(string prompt)
        {
            var api = new OpenAI_API.OpenAIAPI(_config.Key);
            var result = await api.Completions.GetCompletion(prompt);

            return result;
        }

        public async Task<string> CompleteSentenceAdvanced(string prompt)
        {
            var api = new OpenAI_API.OpenAIAPI(_config.Key);
            var result = await api.Completions.CreateCompletionAsync(new CompletionRequest(
                prompt, 
                model: Model.DefaultModel, 
                temperature: 0.2,
                numOutputs: 1,
                max_tokens: 100
                ));

            return result.Completions[0].Text;
        }
    }
}
