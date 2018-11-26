using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace utro_wpf
{
    /// <summary>
    /// Focuses this on load
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperties<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we don't have a control, ignore
            if (!(sender is Control control)) return;

            // If we do have a control, focus the control once loaded
            control.Loaded += (ss, ee) => control.Focus();
        }
    }
}
