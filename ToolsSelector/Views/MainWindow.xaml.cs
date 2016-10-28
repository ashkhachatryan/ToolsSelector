using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ToolsSelector.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;

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

        //public void ImageLoad()
        //{

        //    string root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        //    string[] supportedExtensions = new[] { ".bmp", ".jpeg", ".jpg", ".png", ".tiff" };
        //    var files = Directory.GetFiles(Path.Combine(root, "Images"), "*.*").Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower()));

        //    foreach (var file in files)
        //    {
        //        Tool t = new Tool()
        //        {
        //            Path = file,
        //            Icons = Path.GetFileName(file),
        //        };

        //        BitmapImage img = new BitmapImage();
        //        img.BeginInit();
        //        img.CacheOption = BitmapCacheOption.OnLoad;
        //        img.UriSource = new Uri(file, UriKind.Absolute);
        //        img.EndInit();

        //        FileInfo fi = new FileInfo(file);
        //        x.Add(t);
        //    }


        //    listView.ItemsSource = x;

        //}





        public MainWindow()
        {


            InitializeComponent();

            x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);
            backup = new List<Tool>(x);
            this.DataContext = this;
            //ImageLoad();


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

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        //private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        //{

        //    foreach (var item in x)
        //    {
        //        System.Diagnostics.Process.Start(item.WebPage);

        //    }
        //}

       

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
