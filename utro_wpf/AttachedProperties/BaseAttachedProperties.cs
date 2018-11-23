using System;
using System.Windows;

namespace utro_wpf
{
    /// <summary>
    /// A base attached property to replace the default way of doing things
    /// </summary>
    /// <typeparam name="Parent">The parrent class to be the attached property</typeparam>
    /// <typeparam name="Property">The type of this attached property</typeparam>
    public abstract class BaseAttachedProperties<Parent, Property> where Parent : new()
    {
        #region Public Events

        /// <summary>
        /// Fired when the value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        /// <summary>
        /// Fired when the value is updated even if it's the same
        /// </summary>
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Public Properties

        /// <summary>
        /// A singleton instance of our parent class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Properties Definitions

        /// <summary>
        /// The attached property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = 
            DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperties<Parent, Property>), 
                new UIPropertyMetadata(default(Property), new PropertyChangedCallback(OnValuePropertyChanged), new CoerceValueCallback(OnValuePropertyUpdated)));

        /// <summary>
        /// The called back event when the <see cref="ValueProperty"/> is updated
        /// </summary>
        /// <param name="d">The UI element that has it's proerty changed</param>
        /// <param name="e">The arguments for the event</param>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            // Call the parent function
            (Instance as BaseAttachedProperties<Parent, Property>)?.OnValueUpdated(d, value);

            // Call event listeners
            (Instance as BaseAttachedProperties<Parent, Property>)?.ValueUpdated(d, value);
            return value;
        }

        /// <summary>
        /// The called back event when the <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI element that has it's proerty changed</param>
        /// <param name="e">The arguments for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Call the parent function
            (Instance as BaseAttachedProperties<Parent, Property>)?.OnValueChanged(d, e);

            // Call event listeners
            (Instance as BaseAttachedProperties<Parent, Property>)?.ValueChanged(d, e);
        }

        /// <summary>
        /// Gets the attached property 
        /// </summary>
        /// <param name="d">The element to get the property from</param>
        /// <returns>The value of the property</returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// Sets the attached property
        /// </summary>
        /// <param name="d">The element to set the property value to</param>
        /// <param name="value">The value to be set</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Event Methods

        /// <summary>
        /// The method that is called when any property of this type is changed
        /// </summary>
        /// <param name="sender">The UI element that this property was changed for</param>
        /// <param name="e">The arguments for this event</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        /// <summary>
        /// The method that is called when any property of this type is updated
        /// </summary>
        /// <param name="sender">The UI element that this property was updated for</param>
        /// <param name="e">The value of the object</param>
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }

        #endregion
    }
}