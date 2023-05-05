using GPTsanOekakidesuyoCS.Apis.Requests;
using GPTsanOekakidesuyoCS.Apis.Responses;

namespace GPTsanOekakidesuyoCS.Apis.Services.Interface
{
    public interface IOpenAiService
    {
        Task<OpenAiResponse> Run(OpenAiRequest request);
    }
}
