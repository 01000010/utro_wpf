using System;
using System.Globalization;
using System.Diagnostics;
using utro_wpf.core;
using Ninject;

namespace utro_wpf
{
    /// <summary>
    /// Converts a string to a service name from the IoC
    /// </summary>
    public class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropiate page
            switch ((string)value)
            {
                case nameof(ApplicationViewModel):
                    return IoC.Get<ApplicationViewModel>();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
