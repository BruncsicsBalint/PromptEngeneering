namespace Recommender.Client.DTOs
{
    public class PromptDTO
    {
        public string Prompt { get; set; } = "";

        public PromptDTO(string prompt)
        {
            Prompt = prompt;
        }
    }
}
