using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ToolsSelector.Models;
 
namespace ToolsSelector.Views
{
    class PathConverter : IValueConverter
    {
       

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           

            string root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (value == null)
                return null;
            else
                return root+ value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
