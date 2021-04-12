using System;
using System.Net.Http;
using Dictionary.Console.Api;
using C = System.Console;

namespace Dictionary.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(5);

            var dictionaryApi = new DictionaryApi(httpClient);

            var wordRequest = new DictionaryRequest
            {
                LanguageCode = args[0],
                Word = args[1]
            };
            var wordResponse = dictionaryApi.GetWord(wordRequest);

            if (!wordResponse.Found)
            {
                C.WriteLine("The word/dictionary does not exist in this dictionary");
                return;
            }
            
            C.WriteLine(wordResponse.Word.WordName);
            foreach (var meaning in wordResponse.Word.Meanings)
            {
                C.WriteLine($"- Meaning's part of speech: {meaning.PartOfSpeech}");
                foreach (var definition in meaning.Type)
                {
                    C.WriteLine($"-- Definition: {definition.Definition}");
                    C.WriteLine($"-- Example: {definition.Example}");
                }
            }
        }
    }
}