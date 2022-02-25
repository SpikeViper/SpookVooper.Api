using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Government.Voting
{
    /// <summary>
    /// A candidate pass allows a candidate to run for office even
    /// if they do not fit the requirements
    /// </summary>
    public class CandidatePass
    {
        /// <summary>
        /// The Id of this pass
        /// </summary>
        [Display(Name = "Pass ID")]
        public string Id { get; }

        /// <summary>
        /// The user Id that this pass is for
        /// </summary>
        [Display(Name = "User SVID")]
        public string UserId { get; }

        /// <summary>
        /// The type of election the pass works for
        /// </summary>
        [Display(Name = "Election Type", Description = "The kind of election this applies to.")]
        public string Type { get; }

        /// <summary>
        /// The district this pass applies to
        /// </summary>
        [Display(Name = "District", Description = "The district this pass applies to.")]
        public string District { get; }

        /// <summary>
        /// Bans the candidate from running rather than allowing them
        /// </summary>
        [Display(Name = "Blacklist", Description = "Block the candidate instead of allowing them.")]
        public bool Blacklist { get; }
    }
}
