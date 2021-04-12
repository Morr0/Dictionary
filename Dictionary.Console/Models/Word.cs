using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dictionary.Console.Models
{
    public class Word
    {
        [JsonPropertyName("word")] public string WordName { get; set; }
        [JsonPropertyName("meanings")] public IList<WordMeaning> Meanings { get; set; }
    }
}