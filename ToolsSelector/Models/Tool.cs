using Newtonsoft.Json;

namespace ToolsSelector.Models
{
    public class Tool : Trial
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
        public string[] Type { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "trialPeriod")]
        public Trial TrialPeriod { get; set; }

        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "icons")]
        public string Icons { get; set; }
    }
}
