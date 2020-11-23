using System;
using System.Collections.Generic;
using System.Text;

namespace SpookVooper.Api.Economy.Stocks
{
    public class ValueHistory
    {

        /// <summary>
        /// Unique ID of this object
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// ID of account being tracked
        /// </summary>
        public string Account_Id { get; set; }

        /// <summary>
        /// The value of the account at this time
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// The time this record was made
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// The type of record - can be MINUTE, HOUR, or DAY
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The amount traded during this time
        /// </summary>
        public int Volume { get; set; }
    }
}
