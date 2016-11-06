using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using ToolsSelector.Models;

namespace ToolsSelector.Views
{

    class DistinctConverter : Tool, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            List<Tool> tools = (value as IEnumerable<Tool>).ToList();
            //distinct = list.GetType().GetProperty("Category").GetValue(list, null);
            List<Tool> distinct = null;

            if (parameter.ToString() == "Category")
            {
                distinct = tools.GroupBy(x => x.Category).Select(g => g.First()).ToList();
            }
            else if (parameter.ToString() == "Type")
            {

                    var items = new List<string>();
                    foreach (var item in tools)
                    {
                        foreach (var tool in item.Type)
                        {
                            items.Add(tool);
                        }
                    }

                    items = items.Distinct().ToList();

                    return items;
                
            }
            else if (parameter.ToString() == "ServicesFeatures")
            {
                distinct = tools.GroupBy(x => x.ServicesFeatures).Select(g => g.First()).ToList();
            }
            else if (parameter.ToString() == "TrialPeriod.Period")
            {
                distinct = tools.GroupBy(x => x.TrialPeriod.Period).Select(g => g.First()).ToList();
            }
            else if (parameter.ToString() == "Price")
            {
                distinct = tools.GroupBy(x => x.Price).Select(g => g.First()).ToList();
            }

            return distinct;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
