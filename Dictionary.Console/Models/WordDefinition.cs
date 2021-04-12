using System.Text.Json.Serialization;

namespace Dictionary.Console.Models
{
    public class WordDefinition
    {
        [JsonPropertyName("definition")] public string Definition { get; set; }
        [JsonPropertyName("example")] public string Example { get; set; }
    }
}