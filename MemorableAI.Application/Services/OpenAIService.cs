using MemorableAI.Application.Interfaces;
using MemorableAI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MemorableAI.Application.Services
{
    public class OpenAIService : IOpenAIService
    {
        private const string apiUrl = "https://api.openai.com/v1/chat/completions";
        private readonly IMemorableRepository _repository;
        private readonly HttpClient _client;
        private readonly string apiKey = "";

        public OpenAIService(IMemorableRepository repository, HttpClient httpClient)
        {
            _repository = repository;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }
        async public Task<IEnumerable<Domain.Models.Task>?> GenerateTaskByPrompt(string prompt)
        {
            try
            {
                var requestBody = new
                {
                    model = "gpt-4",  // Use "gpt-3.5-turbo" for lower cost
                    messages = new[]
                    {
                        new { role = "system", content = "You are a helpful assistant." },
                        new { role = "user", content = prompt }
                    }
                };

                var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(apiUrl, jsonContent);

                if (!response.IsSuccessStatusCode) return null;

                var responseContent = await response.Content.ReadAsStringAsync();
                using var jsonDoc = JsonDocument.Parse(responseContent);

                var jsonText =  jsonDoc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine("****OPENIA:ERROR****");
                return null;
            }

        }
    }
}
