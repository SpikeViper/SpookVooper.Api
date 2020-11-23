using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SpookVooper.Api.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class User : IdentityUser, Entity
    {
        // Svid
        [JsonProperty]
        public override string Id { get => base.Id; set => base.Id = value; }

        [JsonProperty]
        public override string UserName { get => base.UserName; set => base.UserName = value; }

        // Other accounts
        [JsonProperty]
        public string twitch_id { get; set; }

        [JsonProperty]
        public ulong? discord_id { get; set; }

        // Forum stuff
        [JsonProperty]
        public int post_likes { get; set; }

        [JsonProperty]
        public int comment_likes { get; set; }

        // NationStates nation
        [JsonProperty]
        public string nationstate { get; set; }

        // Description
        [JsonProperty]
        public string description { get; set; }

        // Credits
        [JsonProperty]
        [Display(Name = "Credits")]
        public decimal Credits { get; set; }

        // API Key
        [JsonIgnore]
        public string Api_Key { get; set; }

        [JsonProperty]
        public int api_use_count { get; set; }

        [JsonProperty]
        public string minecraft_id { get; set; }

        public string Name { get { return UserName; } }

        // Twitch stuff
        [JsonProperty]
        public int twitch_last_message_minute { get; set; }

        [JsonProperty]
        public int twitch_message_xp { get; set; }

        [JsonProperty]
        public int twitch_messages { get; set; }

        // Discord stuff
        [JsonProperty]
        [Display(Name = "Commends")]
        public int discord_commends { get; set; }

        [JsonProperty]
        [Display(Name = "Commends Sent")]
        public int discord_commends_sent { get; set; }

        [JsonProperty]
        [Display(Name = "Last Commend Hour")]
        public int discord_last_commend_hour { get; set; }

        [JsonProperty]
        [Display(Name = "Last Commend Message (ID)")]
        public ulong discord_last_commend_message { get; set; }

        [JsonProperty]
        [Display(Name = "Discord Message XP")]
        public int discord_message_xp { get; set; }

        [JsonProperty]
        [Display(Name = "Discord Messages")]
        public int discord_message_count { get; set; }

        [JsonProperty]
        [Display(Name = "Last Message Minute")]
        public int discord_last_message_minute { get; set; }

        [JsonProperty]
        [Display(Name = "Last Message Time")]
        public DateTime Discord_Last_Message_Time { get; set; }

        [JsonProperty]
        [Display(Name = "Warnings")]
        public int discord_warning_count { get; set; }

        [JsonProperty]
        [Display(Name = "Bans")]
        public int discord_ban_count { get; set; }

        [JsonProperty]
        [Display(Name = "Kicks")]
        public int discord_kick_count { get; set; }

        [JsonProperty]
        [Display(Name = "Game XP")]
        public int discord_game_xp { get; set; }

        // Government Stuff
        [JsonProperty]
        [Display(Name = "District")]
        public string district { get; set; }

        [JsonProperty]
        [Display(Name = "District Move Date")]
        public DateTime? district_move_date { get; set; }

        public string Image_Url { get; set; }

        public decimal Credits_Invested { get; set; }

        public int GetTotalXP()
        {
            return post_likes + comment_likes + (twitch_message_xp * 4) + (discord_commends * 5) + (discord_message_xp * 2) + (discord_game_xp / 100);
        }

        // DISCORD HELPER METHODS

        public int GetDaysSinceLastMove()
        {
            if (district_move_date == null) return int.MaxValue;

            return (int)DateTime.Now.Subtract((DateTime)district_move_date).TotalDays;
        }
    }
}
