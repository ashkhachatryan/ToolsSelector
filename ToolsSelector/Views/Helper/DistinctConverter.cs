using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using ToolsSelector.Models;

namespace ToolsSelector.Views
{

    class DistinctConverter : Tool, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            List<Tool> list = (value as IEnumerable<Tool>).ToList();
            //distinct = list.GetType().GetProperty("Category").GetValue(list, null);
            List<Tool> distinct = null;

            if (parameter.ToString() == "Category")
            {
                distinct = list.GroupBy(x => x.Category).Select(g => g.First()).ToList();
            }
            else if (parameter.ToString() == "Type")
            {
                try
                {
                    foreach (var item in list)
                    {
                            distinct = list.GroupBy(x => x.Type[0]).Select(g => g.First()).ToList();
                        
                    }

                    //foreach (var item in list)
                    //{
                    //    distinct = list.GroupBy(x => x.Type).Select(g => g.First()).ToList();
                    //}


                    //for (int i = 0; i < Type.Length; i++)
                    //{
                    //    distinct = list.GroupBy(x => x.Type[i]).Select(g => g.First()).ToList();
                    //}


                    //distinct = list.GroupBy(x => x.Type[0]).Select(g => g.First()).ToList();


                    //distinct = (List<Tool>)item.Type.Select(g => g.First());

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else if (parameter.ToString() == "ServicesFeatures")
            {
                distinct = list.GroupBy(x => x.ServicesFeatures).Select(g => g.First()).ToList();
            }
            else if (parameter.ToString() == "TrialPeriod.Period")
            {
                distinct = list.GroupBy(x => x.TrialPeriod.Period).Select(g => g.First()).ToList();
            }
            else if (parameter.ToString() == "Price")
            {
                distinct = list.GroupBy(x => x.Price).Select(g => g.First()).ToList();
            }

            return distinct;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
