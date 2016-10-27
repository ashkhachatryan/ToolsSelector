using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ToolsSelector.Models
{
    public class Tool
    {
        [JsonProperty(PropertyName =  "name")]
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

        [JsonProperty(PropertyName ="icons")]
        public string Icons { get; set; }

        public string Path { get; set; } = "/ToolsSelector;component/Images";

        public BitmapImage Image { get; set; }
       //public  static  void ImageSource(string psAssemblyName, string psResourceName)
       // {
       //     Uri oUri = new Uri("pack://application:,,,/" + psAssemblyName + ";component/" + psResourceName, UriKind.RelativeOrAbsolute);
       //      BitmapFrame.Create(oUri);
       // }
    }
}