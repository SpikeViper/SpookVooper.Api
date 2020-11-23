using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.Government.Voting
{
    public class ElectionVote
    {
        ///////////////
        // VOTE INFO //
        ///////////////

        // GUID of the vote
        [Display(Name = "Vote ID")]
        public string Id { get; set; }

        // The choice made in the vote
        [Display(Name = "Vote Choice")]
        public string Choice_Id { get; set; }

        // Date vote was cast
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        // ID of election
        [Display(Name = "Election ID")]
        public string Election_Id { get; set; }

        // True if the election manager invalidated the ballot
        [Display(Name = "Invalidated")]
        public bool Invalid { get; set; }

        ///////////////
        // USER INFO //
        ///////////////

        // ID of voter who cast this vote
        [Display(Name = "Voter ID")]
        public string User_Id { get; set; }
    }
}
