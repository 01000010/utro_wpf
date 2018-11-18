using System;
using System.Windows;
using System.Windows.Controls;

namespace utro_wpf
{
    public class PasswordBoxProperties
    {
        /// <summary>
        /// Dependency property to monitor the password box
        /// </summary>
        public static readonly DependencyProperty MonitorPasswordProperty =
            DependencyProperty.RegisterAttached("MonitorPassword", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false, OnMonitorPasswordChanged));

        /// <summary>
        /// The actual event to listen to
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = d as PasswordBox;

            if (passwordBox == null) { }

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((bool)e.NewValue)
            {
                SetHasText(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SetHasText((PasswordBox)sender);
        }

        /// <summary>
        /// Setter for the dependency property password monitor
        /// </summary>
        /// <param name="element"></param>
        public static void SetMonitorPassword(PasswordBox element, bool value)
        {
            element.SetValue(MonitorPasswordProperty, value);
        }

        /// <summary>
        /// Getter for the dependency property password monitor
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool GetMonitorPassword(PasswordBox element)
        {
            return (bool)element.GetValue(MonitorPasswordProperty);
        }

        /// <summary>
        /// Dependency property to determine if the password box has text
        /// </summary>
        public static readonly DependencyProperty HasTextProperty = 
            DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false));

        /// <summary>
        /// Setter for the dependency property has text of the password box
        /// </summary>
        /// <param name="element"></param>
        private static void SetHasText(PasswordBox element)
        {
            element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
        }

        /// <summary>
        /// Getter for the dependency property has text of the passwowrd box
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool GetHasText(PasswordBox element)
        {
            return (bool)element.GetValue(HasTextProperty);
        }
    }
}