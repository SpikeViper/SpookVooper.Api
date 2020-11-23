using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.Nerdcraft
{
    public class Player
    {
        [Key]
        public string UUID { get; set; }
        public string ApiKey { get; set; }
        public string SVID { get; set; }
        public string Name { get; set; }
        public string DiscordRoles { get; set; }
        public string Job { get; set; }
        public DateTime LastKitUse { get; set; }
        public decimal Credits { get; set; }
    }
}
