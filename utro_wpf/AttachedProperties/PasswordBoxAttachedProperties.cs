using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace utro_wpf
{
    /// <summary>
    /// The MonitorPassword property for <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperties<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the caller
            PasswordBox passwordBox = sender as PasswordBox;

            // Make sure it is a password box
            if (passwordBox == null) return;

            // Remove any previous events
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            // If the caller set MonitorPassword to true start listening out for password changes
            if ((bool)e.NewValue)
            {
                HasTextProperty.SetValue(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        /// <summary>
        /// Event fired when the password box changes values
        /// </summary>
        /// <param name="sender">The password box</param>
        /// <param name="e">Events</param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Set the attached HasText value
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// The HasText attached property for <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty : BaseAttachedProperties<HasTextProperty, bool>
    {
        /// <summary>
        /// Sets the HasText property value, based on if the <see cref="PasswordBox"/> has any text
        /// </summary>
        /// <param name="sender">The passed <see cref="PasswordBox"/></param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}
