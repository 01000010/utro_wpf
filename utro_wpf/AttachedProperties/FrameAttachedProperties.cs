using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace utro_wpf
{
    /// <summary>
    /// The is no frame history attached property for removing navigation out of the pages
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperties<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the frame
            Frame frame = (sender as Frame);
            // Hide the navigation bar
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            // Clear history on navigate
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
