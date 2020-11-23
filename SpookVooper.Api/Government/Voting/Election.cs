using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpookVooper.Api.Government.Voting
{
    public class Election
    {
        [Display(Name = "Election ID")]
        public string Id { get; set; }

        // District the election is for
        [Display(Name = "District")]
        public string District { get; set; }

        // Time the election began
        [Display(Name = "Start Date")]
        public DateTime Start_Date { get; set; }

        // Time the election ended
        [Display(Name = "Start Date")]
        public DateTime End_Date { get; set; }

        // The resulting winner of the election
        [Display(Name = "Winner ID")]
        public string Winner_Id { get; set; }

        // False if the election has been ended
        [Display(Name = "Active")]
        public bool Active { get; set; }

        // The kind of election this is
        [Display(Name = "Type")]
        public string Type { get; set; }
    }
}
