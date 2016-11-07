using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ToolsSelector.Models;
using System.Diagnostics;
using System.Windows.Controls;

namespace ToolsSelector
{
    public partial class TheTools : Window, INotifyPropertyChanged

    {
        string jsonFile = File.ReadAllText(@"Resources\Json.json");

        public List<Tool> tools { get; set; }
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
                        var current = tools.Where(x => x.Category == SelectedTool.Category).ToList();
                        tools = new List<Tool>(current);

                        RaisePropertyChanged("tools");
                        refreshButton.Click += Refresh_Click;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public TheTools()
        {

            InitializeComponent();
            try
            {
                tools = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);
                backup = new List<Tool>(tools);
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
            tools = backup;
            RaisePropertyChanged("tools");
        }


        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            descriptionTextBox.Clear();
            availabilityCheckBox.IsChecked = false;
            creditCardCheckBox.IsChecked = false;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string name = (sender as System.Windows.Controls.Image).Tag.ToString();
                string current = tools.Where(x => x.Name == name).ToList()[0].Description;
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

        private void availableCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            availabilityCheckBox = (CheckBox)sender;

            if (availabilityCheckBox.IsChecked == true)
            {
                var tool = tools.Where(x => x.TrialPeriod.Availability == "available").ToList();
                tools = new List<Tool>(tool);
                RaisePropertyChanged("tools");
            }
        }

        private void availabilityCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (availabilityCheckBox.IsChecked == false)
            {
                Refresh();
            }
        }

        private void creditCardCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (creditCardCheckBox.IsChecked == true)
            {
                var current = tools.Where(x => x.TrialPeriod.CreditCard == "not required").ToList();
                tools = new List<Tool>(current);
                RaisePropertyChanged("tools");
            }


        }

        private void creditCardCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (creditCardCheckBox.IsChecked == false)
            {
                Refresh();
            }
        }



        private void typeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Tool> newTools = new List<Tool>();
            List<Tool> toolsCopy = new List<Tool>(tools);
            if ((sender as ComboBox).Name == "typeCombo")
            {
                foreach (var item in tools)
                {
                    if (!item.Type.Contains(typeCombo.SelectedValue))
                    {
                        newTools.Add(item);
                    }
                }

                foreach (var item in newTools)
                {
                    toolsCopy.Remove(item);
                }
            }
            tools = new List<Tool>(toolsCopy);
            RaisePropertyChanged("tools");

        }

        private void nameCombo_TextChanged(object sender, RoutedEventArgs e)
        {
          
        }

        private void nameCombo_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            nameCombo.IsDropDownOpen = true;
        }

        private void nameCombo_GotFocus(object sender, RoutedEventArgs e)
        {
            nameCombo.IsDropDownOpen = true;
        }

        


    }
}
