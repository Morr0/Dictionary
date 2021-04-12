using Dictionary.Console.Models;

namespace Dictionary.Console.Api
{
    public class DictionaryResponse
    {
        public bool Found { get; set; }
        public Word Word { get; set; }
    }
}