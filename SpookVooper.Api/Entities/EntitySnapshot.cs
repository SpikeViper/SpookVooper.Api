using System.Text.Json.Serialization;

namespace SpookVooper.Api.Entities
{
    public class EntitySnapshot
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("credits")]
        public decimal Credits { get; }

        [JsonPropertyName("image_url")]
        public string Avatar { get; }
    }
}
