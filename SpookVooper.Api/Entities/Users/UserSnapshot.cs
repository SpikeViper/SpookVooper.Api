using System.Text.Json.Serialization;

namespace SpookVooper.Api.Entities
{
    /// <summary>
    /// This class exists to strip out sensitive data and provide only what the API
    /// should pass to endpoints. It does not automatically update and serves as a "snapshot" of the user at that moment.
    /// </summary>
    public class UserSnapshot : EntitySnapshot
    {

        [JsonPropertyName("userName")]
        public string Username { get; set; }

        // Other accounts
        [JsonPropertyName("twitch_id")]
        public string TwitchID { get; set; }

        [JsonPropertyName("discord_id")]
        public ulong? DiscordID { get; set; }

        // Forum stuff

        [JsonPropertyName("post_likes")]
        public int PostLikes { get; set; }

        [JsonPropertyName("comment_likes")]
        public int CommentLikes { get; set; }

        // NationStates nation

        [JsonPropertyName("nationstate")]
        public string Nationstate { get; set; }

        // Description

        [JsonPropertyName("description")]
        public string Description { get; set; }


        [JsonPropertyName("api_use_count")]
        public int ApiUseCount { get; set; }


        [JsonPropertyName("minecraft_id")]
        public string MinecraftId { get; set; }

        // Twitch stuff

        [JsonPropertyName("twitch_last_message_minute")]
        public int TwitchLastMessageMinute { get; set; }


        [JsonPropertyName("twitch_message_xp")]
        public int TwitchMessageXP { get; set; }


        [JsonPropertyName("twitch_messages")]
        public int TwitchMessages { get; set; }

        // Discord stuff

        [JsonPropertyName("discord_commends")]
        public int DiscordCommends { get; set; }


        [JsonPropertyName("discord_commends_sent")]
        public int DiscordCommendsSent { get; set; }


        [JsonPropertyName("discord_last_commend_hour")]
        public int DiscordLastCommendHour { get; set; }


        [JsonPropertyName("discord_last_commend_message")]
        public ulong DiscordLastCommendMessage { get; set; }


        [JsonPropertyName("discord_message_xp")]
        public int DiscordMessageXp { get; set; }


        [JsonPropertyName("discord_message_count")]
        public int DiscordMessageCount { get; set; }


        [JsonPropertyName("discord_last_message_minute")]
        public int DiscordLastMessageMinute { get; set; }


        [JsonPropertyName("discord_warning_count")]
        public int DiscordWarningCount { get; set; }


        [JsonPropertyName("discord_ban_count")]
        public int DiscordBanCount { get; set; }


        [JsonPropertyName("discord_kick_count")]
        public int DiscordKickCount { get; set; }


        [JsonPropertyName("discord_game_xp")]
        public int DiscordGameXP { get; set; }

        // Government Stuff

        [JsonPropertyName("district")]
        public string District { get; set; }
    }
}
