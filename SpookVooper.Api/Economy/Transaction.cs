using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.Economy
{
    public class Transaction
    {
        [Key]
        public string ID { get; set; }
        public decimal Credits { get; set; }
        public DateTime Time { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public string Details { get; set; }
    }
}
