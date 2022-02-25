using System;
using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Government.Voting
{
    public class ElectionVote
    {
        ///////////////
        // VOTE INFO //
        ///////////////

        // GUID of the vote
        [Display(Name = "Vote ID")]
        public string Id { get; }

        // The choice made in the vote
        [Display(Name = "Vote Choice")]
        public string Choice_Id { get; }

        // Date vote was cast
        [Display(Name = "Date")]
        public DateTime Date { get; }

        // ID of election
        [Display(Name = "Election ID")]
        public string Election_Id { get; }

        // True if the election manager invalidated the ballot
        [Display(Name = "Invalidated")]
        public bool Invalid { get; }

        ///////////////
        // USER INFO //
        ///////////////

        // ID of voter who cast this vote
        [Display(Name = "Voter ID")]
        public string User_Id { get; }
    }
}
