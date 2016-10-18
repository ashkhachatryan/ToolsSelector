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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CategoryCombo_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);

                foreach (var tool in x)
                {
                    if (!categoryCombo.Items.Contains(tool.Category))
                    {
                        categoryCombo.Items.Add(tool.Category);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void WebPageCombo_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);

                foreach (var tool in x)
                {
                    webPageCombo.Items.Add(tool.WebPage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DescriptionCombo_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);

                foreach (var tool in x)
                {
                    descriptionCombo.Items.Add(tool.Description);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void NameCombo_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);

                foreach (var tool in x)
                {
                    nameCombo.Items.Add(tool.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FeaturesCombo_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);

                foreach (var tool in x)
                {
                    if (!featuresCombo.Items.Contains(tool.ServicesFeatures))
                    {
                        featuresCombo.Items.Add(tool.ServicesFeatures);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TypeCombo_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);

                foreach (var tool in x)
                {
                    if (!typeCombo.Items.Contains(tool.Type))
                    {
                        typeCombo.Items.Add(tool.Type);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TrialPeriodCombo_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);

                foreach (var tool in x)
                {
                    if (!trialPeriodCombo.Items.Contains(tool.TrialPeriod))
                    {
                        trialPeriodCombo.Items.Add(tool.TrialPeriod);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void priceCombo_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = JsonConvert.DeserializeObject<List<Tool>>(jsonFile);

                foreach (var tool in x)
                {
                    if (!priceCombo.Items.Contains(tool.Price))
                    {
                        priceCombo.Items.Add(tool.Price);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
