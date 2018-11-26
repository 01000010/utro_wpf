using System.Windows;

namespace utro_wpf
{
    /// <summary>
    /// A base class to run any animation method
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperties<Parent, bool> where Parent : BaseAttachedProperties<Parent, bool>, new()
    {
        #region Public properties

        /// <summary>
        /// A flag to indicate if it's the first time this has happened
        /// </summary>
        public bool FirstLoad { get; set; } = true;

        #endregion

        /// <summary>
        /// The function that gets fired everytime you update the property
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="value">The new value</param>
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // Get the framework element
            if (!(sender is FrameworkElement element)) return;
            // Don't fire if it's not changed
            if (sender.GetValue(ValueProperty) == value && !FirstLoad) return;

            // On first load
            if (FirstLoad)
            {
                // Create a single self-unhookable event for the elements loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    // Unhook ourselves
                    element.Loaded -= onLoaded;
                    // Do the desired animation
                    DoAnimation(element, (bool)value);
                    // Make sure we are not in firsload
                    FirstLoad = false;
                };

                // Hook into the loaded event of the element
                element.Loaded += onLoaded;
            }
            else
            {
                DoAnimation(element, (bool)value);
            }
        }

        /// <summary>
        /// The animation method that is fired and the value changes
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected virtual void DoAnimation(FrameworkElement element, bool value) { }
    }

    /// <summary>
    /// Animates a framework element sliding in from the left on show and sliding back to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.SlideAndFadeInFromLeft(FirstLoad ? 0 : 0.3f, keepMargins: false);
            }
            else
            {
                await element.SlideAndFadeOutToLeft(FirstLoad ? 0 : 0.3f, keepMargins: false);
            }
        }
    }

    /// <summary>
    /// Animates a framework element sliding up from the bottom on show
    /// and sliding out to the bottom on hide
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: true);
            else
                await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: true);
        }
    }
}
