using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace SpookVooper.Api.News
{
    public class PressPass
    {
        [Key]
        public string GroupID { get; set; }
    }
}
