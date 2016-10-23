using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using ToolsSelector.Models;

namespace ToolsSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        string jsonFile = File.ReadAllText(@"Resources\Json.json");

        public List<Tool> x { get; set; }
        public List<Tool> backup { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        Tool _selectedTool = null;

        public Tool SelectedTool
        {
            get
            {
                return _selectedTool;
            }
            set
            {
                if (_selectedTool != value)
                {
                    _selectedTool = value;
                    var t = x.Where(x => x.Category == SelectedTool.Category).ToList();
                    x = new List<Tool>(t);

                    RaisePropertyChanged("x");
                    refreshButton.Click += Refresh_Click;
                }
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);
            backup = new List<Tool>(x);
            this.DataContext = this;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }




        public void Refresh()
        {
            x = backup;
            RaisePropertyChanged("x");
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
