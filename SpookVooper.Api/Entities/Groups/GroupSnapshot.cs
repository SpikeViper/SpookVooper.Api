using System.Text.Json.Serialization;

namespace SpookVooper.Api.Entities
{
    public class GroupSnapshot : EntitySnapshot
    {

        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("open")]
        public bool Open { get; }

        [JsonPropertyName("group_category")]
        public string GroupCategory { get; }

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; }

        [JsonPropertyName("district_id")]
        public string DistrictId { get; }

        [JsonPropertyName("default_role_id")]
        public string DefaultRoleId { get; }

        [JsonPropertyName("credits_invested")]
        public decimal CreditsInvested { get; }
    }
}
