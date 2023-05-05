using GPTsanOekakidesuyoCS.Apis.Interface;
using GPTsanOekakidesuyoCS.Apis.Requests;
using GPTsanOekakidesuyoCS.Apis.Responses;
using GPTsanOekakidesuyoCS.Apis.Services.Interface;
using System.Text;
using System.Text.Json;

namespace GPTsanOekakidesuyoCS.Apis.Services
{
    public class OpenAiService : IOpenAiService
    {
        public async Task<OpenAiResponse> Run(OpenAiRequest request)
        {
            var response = CallChatGptApi(request);
        }

        private async Task CallChatGptApi(OpenAiRequest request)
        {
            // Httpクライアントを初期化
            var httpClient = new HttpClient();

            using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    model = request.model,
                    messages = request.messages,
                    temperature = request.temperature
                }),
                Encoding.UTF8,
                "appplication/json");

            jsonContent.Headers.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPEN_AI_API_KEY")}");

            var response = httpClient.PostAsync(
                Environment.GetEnvironmentVariable("OPEN_AI_API_ENDPOINT"),
                jsonContent
            );
        }
    }
}
