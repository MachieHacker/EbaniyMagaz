using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EbaniyMagaz.Data
{
    public class PathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
         
            string path = string.Format("C:\\Users\\Banana\\source\\repos\\MachieHacker\\EbaniyMagaz\\Images\\{0}", value);
            if (File.Exists(path))
            {
                return path;
            }
            else
            {
                return "C:\\Users\\Banana\\source\\repos\\MachieHacker\\EbaniyMagaz\\Images\\TestImage.jpg";
            }
            
        }
            //return string.Format("C:\\Users\\Banana\\Desktop\\{0}",value);


            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
            return value;
            }
 
    }
}
