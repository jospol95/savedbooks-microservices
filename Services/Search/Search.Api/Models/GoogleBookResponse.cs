using System.Text.Json.Serialization;

namespace Search.Api.Models
{
    public class GoogleBookResponse
    {
        [JsonPropertyName("items")]
        Item[] Items { get; set; }

        [JsonPropertyName("totalItems")]
        public int TotalItems { get; set; }
    }

    public class Item
    {
        [JsonPropertyName("id")]
        string Id { get; set; }

        [JsonPropertyName("volumeInfo")]
        public VolumeInfo VolumeInfo { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class VolumeInfo
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("authors")]
        public string[] Authors { get; set; }
    }
}
