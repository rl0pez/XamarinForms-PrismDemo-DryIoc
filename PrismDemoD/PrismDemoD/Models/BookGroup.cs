using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemoD.Models
{
    public class BookGroup
    {
        [JsonProperty("UniqueId")]
        public string ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonProperty("Items")]
        public List<Book> Books { get; set; }
    }
}
