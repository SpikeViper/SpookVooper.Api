using System.Text.Json.Serialization;

namespace SpookVooper.Api.Entities
{
    public class GroupSnapshot : EntitySnapshot
    {

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("open")]
        public bool Open { get; set; }

        [JsonPropertyName("group_category")]
        public string GroupCategory { get; set; }

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }

        [JsonPropertyName("district_id")]
        public string DistrictId { get; set; }

        [JsonPropertyName("default_role_id")]
        public string DefaultRoleId { get; set; }

        [JsonPropertyName("credits_invested")]
        public decimal CreditsInvested { get; set; }
    }
}
