using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SpookVooper.Api.Entities
{
    public interface Entity
    {
        public string Id { get; }
        public string Name { get; }
        public decimal Credits { get; set; }
        public string Image_Url { get; }
        public decimal Credits_Invested { get; set; }
        public string Api_Key { get; set; }
    }
}
