namespace Recommender.Services
{
    public interface IOpenAIService
    {
        Task<string> CompleteSentence(string prompt);
        Task<string> CompleteSentenceAdvanced(string prompt);
    }
}
