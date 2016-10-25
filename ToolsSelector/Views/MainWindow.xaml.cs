using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ToolsSelector.Models;
using static System.Net.Mime.MediaTypeNames;

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
        public ICommand ButtonClicked { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private Tool _selectedTool = null;

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


        //public void ImageLoad()
        //{

        //    BitmapImage src = new BitmapImage();
        //    src.BeginInit();
        //    src.UriSource = new Uri("picture.jpg", UriKind.Relative);
        //    src.EndInit();

        //    i.Stretch = Stretch.Uniform;
        //    //int q = src.PixelHeight;        // Image loads here
        //    sp.Children.Add(i);
        //}

        public static readonly List<string> ImageExtensions = new List<string>
       {
            ".jpg",
            ".jpe",
            ".bmp",
            ".gif",
            ".png"
       };


        public void ImageLoad()
        {
            Directory.GetFiles(@"Images\", ".jpg");
        }

        public void Refresh()
        {
            x = backup;
            RaisePropertyChanged("x");
        }

       

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
