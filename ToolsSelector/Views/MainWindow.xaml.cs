using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class  MainWindow :  Window,INotifyPropertyChanged
    {
        string jsonFile = File.ReadAllText(@"Resources\Json.json");

        public List<Tool> x { get; set; }
        public List<Tool> backup { get; set; }
             

        public event PropertyChangedEventHandler PropertyChanged;

        Tool _SelectedTool = null;

        public Tool SelectedTool
        {
            get
            {
                return _SelectedTool;
            }
            set
            {
                backup = x;

                if (_SelectedTool != value)
                {
                    _SelectedTool = value;
                    var t = x.Where(x => x.Category == SelectedTool.Category).ToList();
                    x = new List<Tool>(t);
                    RaisePropertyChanged("x");
                }
            }
        }



        public MainWindow()
        {
            InitializeComponent();
            x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);
            backup = new List<Tool>();
            this.DataContext = this;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

      

        //private void categoryCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //    nameCombo.ItemsSource = null;

        //    nameCombo.Items.Add("tool");

        //    nameCombo.Items.Refresh();
        //}

    }
}
