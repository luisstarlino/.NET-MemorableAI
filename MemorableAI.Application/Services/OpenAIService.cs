using MemorableAI.Application.Interfaces;
using MemorableAI.Domain.Helpers;
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
            _client = httpClient;
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }
        async public Task<List<Domain.Models.Task>?> GenerateTaskByPrompt(string prompt)
        {
            try
            {
                //------------------------------------------------------------------------------------------------
                // R1. Call AI
                //------------------------------------------------------------------------------------------------
                var requestBody = new
                {
                    model = "gpt-4",  // Use "gpt-3.5-turbo" for lower cost
                    messages = new[]
                    {
                        new { role = "system", content = "Você é um assistente útil que transforma textos em listas de tarefas em JSON." },
                        new { role = "user", content = GeneratePrompt(prompt) }
                    }
                };

                using var jsonContent = new StringContent( JsonSerializer.Serialize(requestBody), Encoding.UTF8,"application/json");
                var response = await _client.PostAsync(apiUrl, jsonContent);

                //------------------------------------------------------------------------------------------------
                // R2. Check results
                //------------------------------------------------------------------------------------------------
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"****OPENIA:STATUS ERROR {response.StatusCode}****");
                    return null;
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                using var jsonDoc = JsonDocument.Parse(responseContent);
                var contentText = jsonDoc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                if (contentText!.IsEmpty())
                {
                    Console.WriteLine("****OPENIA:CONTENT EMPTY****");
                    return null;
                }

                //------------------------------------------------------------------------------------------------
                // R3. Get Tasks
                //------------------------------------------------------------------------------------------------
                var tasks = JsonSerializer.Deserialize<List<Domain.Models.Task>>(contentText!, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                
                if (tasks is null) return null;

                //------------------------------------------------------------------------------------------------
                // R4. Save Takss
                //------------------------------------------------------------------------------------------------
                foreach(var t in tasks)
                {
                    t.CreateBy = "OPENAI";
                    await _repository.AddNewTask(t);
                }

                return tasks;

            }
            catch (Exception ex)
            {
                Console.WriteLine("****OPENIA:ERROR****");
                return null;
            }

        }

        private string GeneratePrompt(string prompt)
        {
            string promptGenerate = $@"
                Extraia as tarefas do texto fornecido. Para cada tarefa, crie um título curto e uma descrição. Responda no seguinte formato JSON:
                [
                  {{""title"": ""Título da Tarefa"", ""description"": ""Descrição da Tarefa""}}
                ]
                Exemplo:  
                Entrada: ""Amanhã cedo preciso ir ao mercado, para comprar pão e ovo.""  
                Saída esperada:  
                [{{""title"": ""Mercado Amanhã"", ""description"": ""Comprar pão e ovo""}}]

                Agora processe o seguinte texto:
                ""{prompt}""
             ";
            return promptGenerate;
        }
    }
}
