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
        public string Id { get; }

        /// <summary>
        /// ID of account being tracked
        /// </summary>
        public string Account_Id { get; }

        /// <summary>
        /// The value of the account at this time
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// The time this record was made
        /// </summary>
        public DateTime Time { get; }

        /// <summary>
        /// The type of record - can be MINUTE, HOUR, or DAY
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// The amount traded during this time
        /// </summary>
        public int Volume { get; }
    }
}
