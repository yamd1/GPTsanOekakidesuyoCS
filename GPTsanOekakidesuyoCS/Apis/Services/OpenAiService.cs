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
            var response = await CallChatGptApi(request);
            return CreateResponse(response);
        }

        private async Task<HttpResponseMessage> CallChatGptApi(OpenAiRequest request)
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

            var response = await httpClient.PostAsync(
                Environment.GetEnvironmentVariable("OPEN_AI_API_ENDPOINT"),
                jsonContent
            );

            if (!response.IsSuccessStatusCode)
                throw new Exception("OpenAi API 疎通エラー");

            return response;
        }

        private OpenAiResponse CreateResponse(HttpResponseMessage response)
        { 
            var openAiResponse = new OpenAiResponse();
            openAiResponse.message = CreateOpenAiMessage(response);
            return openAiResponse;
        }

        private IOpenAiMessage CreateOpenAiMessage(HttpResponseMessage response)
        {
            var res = response.Content.ReadAsStringAsync();
            Console.WriteLine(res);

            IOpenAiMessage openAiMessage = new OpenAiMessage();
            openAiMessage.role = "tes";
            openAiMessage.content = "ts";

            return openAiMessage;

        }
    }
}
