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
        public string Username { get; }

        // Other accounts
        [JsonPropertyName("twitch_id")]
        public string TwitchID { get; }

        [JsonPropertyName("discord_id")]
        public ulong? DiscordID { get; }

        // Forum stuff

        [JsonPropertyName("post_likes")]
        public int PostLikes { get; }

        [JsonPropertyName("comment_likes")]
        public int CommentLikes { get; }

        // NationStates nation

        [JsonPropertyName("nationstate")]
        public string Nationstate { get; }

        // Description

        [JsonPropertyName("description")]
        public string Description { get; }


        [JsonPropertyName("api_use_count")]
        public int ApiUseCount { get; }


        [JsonPropertyName("minecraft_id")]
        public string MinecraftId { get; }

        // Twitch stuff

        [JsonPropertyName("twitch_last_message_minute")]
        public int TwitchLastMessageMinute { get; }


        [JsonPropertyName("twitch_message_xp")]
        public int TwitchMessageXP { get; }


        [JsonPropertyName("twitch_messages")]
        public int TwitchMessages { get; }

        // Discord stuff

        [JsonPropertyName("discord_commends")]
        public int DiscordCommends { get; }


        [JsonPropertyName("discord_commends_sent")]
        public int DiscordCommendsSent { get; }


        [JsonPropertyName("discord_last_commend_hour")]
        public int DiscordLastCommendHour { get; }


        [JsonPropertyName("discord_last_commend_message")]
        public ulong DiscordLastCommendMessage { get; }


        [JsonPropertyName("discord_message_xp")]
        public int DiscordMessageXp { get; }


        [JsonPropertyName("discord_message_count")]
        public int DiscordMessageCount { get; }


        [JsonPropertyName("discord_last_message_minute")]
        public int DiscordLastMessageMinute { get; }


        [JsonPropertyName("discord_warning_count")]
        public int DiscordWarningCount { get; }


        [JsonPropertyName("discord_ban_count")]
        public int DiscordBanCount { get; }


        [JsonPropertyName("discord_kick_count")]
        public int DiscordKickCount { get; }


        [JsonPropertyName("discord_game_xp")]
        public int DiscordGameXP { get; }

        // Government Stuff

        [JsonPropertyName("district")]
        public string District { get; }
    }
}
