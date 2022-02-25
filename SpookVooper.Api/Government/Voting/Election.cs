using System;
using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Government.Voting
{
    public class Election
    {
        [Display(Name = "Election ID")]
        public string Id { get; }

        // District the election is for
        [Display(Name = "District")]
        public string District { get; }

        // Time the election began
        [Display(Name = "Start Date")]
        public DateTime Start_Date { get; }

        // Time the election ended
        [Display(Name = "Start Date")]
        public DateTime End_Date { get; }

        // The resulting winner of the election
        [Display(Name = "Winner ID")]
        public string Winner_Id { get; }

        // False if the election has been ended
        [Display(Name = "Active")]
        public bool Active { get; }

        // The kind of election this is
        [Display(Name = "Type")]
        public string Type { get; }
    }
}
