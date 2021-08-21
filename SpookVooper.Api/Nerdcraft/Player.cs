using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.Nerdcraft
{
    public class Player
    {
        [Key]
        public string UUID { get; }
        public string ApiKey { get; }
        public string SVID { get; }
        public string Name { get; }
        public string DiscordRoles { get; }
        public string Job { get; }
        public DateTime LastKitUse { get; }
        public decimal Credits { get; }
    }
}
