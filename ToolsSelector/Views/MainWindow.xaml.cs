using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToolsSelector.Models;

namespace ToolsSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class  MainWindow :  Window
    {
        string jsonFile = File.ReadAllText(@"Resources\Json.json");

        //public Tool SelectedTool { get
        //    {
        //        return null;

        //    }
        //    set
        //    {
        //        int a = 0;
        //    }

        //        }

        public List<Tool> x { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);
            this.DataContext = this;
        }

    }
}
