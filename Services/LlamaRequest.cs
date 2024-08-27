using System;
using System.Text.Json.Nodes;
using GroqApiLibrary;

namespace llama_api.Services;

public class LlamaRequest
{
    static async Task<string> Prompt(string prompt) 
    {
        var apiKey = Environment.GetEnvironmentVariable("API_KEY");

        if (apiKey == null)
        {
            throw new Exception("API_KEY is not set");
        }

        var client = new GroqApiClient(apiKey);

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

        var response = await client.CreateChatCompletionAsync(request);
        var message = response?["choices"]?[0]?["message"]?["content"]?.ToString();

        return message ?? "";
    }
}
