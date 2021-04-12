using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Dictionary.Console.Models;

namespace Dictionary.Console.Api
{
    public class DictionaryApi
    {
        private static string Endpoint = "https://api.dictionaryapi.dev/api/v2/entries";
        
        private readonly HttpClient _httpClient;

        public DictionaryApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public DictionaryResponse GetWord(DictionaryRequest request)
        {
            string url = $"{Endpoint}/{request.LanguageCode}/{request.Word}";
            var message = new HttpRequestMessage(HttpMethod.Get, url);
            message.Content = new StringContent(string.Empty);

            var response = _httpClient.Send(message);

            if (!response.IsSuccessStatusCode)
                return new DictionaryResponse
                {
                    Found = false
                };

            var responseData = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            var reader = new Utf8JsonReader(responseData);
            var word = JsonSerializer.Deserialize<List<Word>>(ref reader, new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
            })?[0];

            return new DictionaryResponse
            {
                Found = true,
                Word = word
            };
        }
    }
}