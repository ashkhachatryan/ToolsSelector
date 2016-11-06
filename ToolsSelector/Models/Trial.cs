using Newtonsoft.Json;


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
