using Newtonsoft.Json;

namespace PrismDemoD.Models
{
    public class Book
    {
        [JsonProperty("UniqueId")]
        public string ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string FirstName { get; set; }
        public bool Read { get; set; }
    }
}
