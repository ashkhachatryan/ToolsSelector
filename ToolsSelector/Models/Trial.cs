using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsSelector.Models
{
   public class Trial
    {
        [JsonProperty(PropertyName = "availability")]
        public string Availability { get; set; }

        [JsonProperty(PropertyName = "credit-card")]
        public string CreditCard { get; set; }

        [JsonProperty(PropertyName = "period")]
        public string Period { get; set; }


    }
}
