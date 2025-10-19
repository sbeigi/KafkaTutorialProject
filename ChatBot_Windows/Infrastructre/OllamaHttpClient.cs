using ChatBot_Windows.App.DTO;
using System.Net.Http.Json;
using System.Text;

namespace ChatBot_Windows.Infrastructre;
public class OllamaHttpClient
{
    private readonly string _baseUrl = "http://127.0.0.1:11434";
    private readonly string _path = "/api/chat";
    private readonly HttpClient _httpClient;
    public OllamaHttpClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_baseUrl)
        };
    }
    public async IAsyncEnumerable<ChatCompletionResponseDTO> ChatCompletion(string Message)
    {
        var request = new HttpRequestMessage
        {
            RequestUri = new Uri(_path),
            Method = HttpMethod.Post,
            Content = new StringContent(Message, Encoding.UTF8, "application/json")
        };

        var result = _httpClient.GetFromJsonAsAsyncEnumerable<ChatCompletionResponseDTO>(_path);

        await foreach (var item in result)
        {
            if(item is null)
                continue;

            yield return item;
        }
    }
}
