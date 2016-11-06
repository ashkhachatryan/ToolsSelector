using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;


namespace ToolsSelector.Views
{
    class PathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder build = new  StringBuilder();
            string root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string path = "";
            if (value == null)
                return null;
            else
                path = build.Append(root).Append(@"\Resources\Images\").Append(value.ToString()).ToString();

            return path;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
