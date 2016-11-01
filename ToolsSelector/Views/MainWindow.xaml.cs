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
using System.Diagnostics;
using System.Windows.Controls;

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
                try
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
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }


        public MainWindow()
        {

            InitializeComponent();
            try
            {
                x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);
                backup = new List<Tool>(x);
                this.DataContext = this;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         

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
            descriptionTextBox.Clear();
            RaisePropertyChanged("x");
        }


        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string name = (sender as System.Windows.Controls.Image).Tag.ToString();
                string current = x.Where(x => x.Name == name).ToList()[0].Description;
                descriptionTextBox.Text = current;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
                Uri uri = new Uri(@"http://" + e.Uri.ToString());
                Process.Start(new ProcessStartInfo(uri.AbsoluteUri));
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
