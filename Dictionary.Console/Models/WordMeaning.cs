using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dictionary.Console.Models
{
    public class WordMeaning
    {
        [JsonPropertyName("partOfSpeech")] public string PartOfSpeech { get; set; }
        [JsonPropertyName("definitions")] public IList<WordDefinition> Type { get; set; }
    }
}