using System;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace llama_api.Services;

public class LlamaRequest
{
    private readonly HttpClient _http = new();
    private const string Url = "https://api.groq.com/openai/v1/chat/completions";

    public LlamaRequest()
    {
        var apiKey = Environment.GetEnvironmentVariable("API_KEY") ?? throw new InvalidDataException("API_KEY is not set");

        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
    }

    public async Task<string> Prompt(string prompt) 
    {
        var request = new JsonObject
        {
            ["model"] = "llama3-8b-8192",
            ["messages"] = new JsonArray
            {
                new JsonObject
                {
                    ["role"] = "user",
                    ["content"] = prompt
                }
            }
        };

        var response = await _http.PostAsJsonAsync(Url, request);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"API request failed with status code {response.StatusCode}. Response content: {errorContent}");
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        var jsonResponse = JsonNode.Parse(responseBody);

        var message = jsonResponse?["choices"]?[0]?["message"]?["content"]?.ToString();

        return message ?? "";
    }
}
