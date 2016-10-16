using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsSelector.Models
{
    public class Tool
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "webPage")]
        public string WebPage { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "servicesfeatures")]
        public string ServicesFeatures { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "trialPeriod")]
        public string TrialPeriod { get; set; }

        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }
    }
}