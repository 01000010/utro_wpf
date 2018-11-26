using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace utro_wpf
{
    /// <summary>
    /// Helpers to animate framework elements in specific ways
    /// </summary>
    public static class FrameworkElementAnimation
    {

        /// <summary>
        /// Slides an element in from the right
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The amount of seconds the animation should take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargins = true)
        {
            if (seconds == 0) element.Visibility = Visibility.Hidden;
            // Create the story board
            Storyboard sb = new Storyboard();
            sb.AddSlideFromRight(seconds, element.ActualWidth, keepMargin: keepMargins);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides an element in from the right
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The amount of seconds the animation should take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargins = true)
        {
            if (seconds == 0) element.Visibility = Visibility.Hidden;
            // Create the story board
            Storyboard sb = new Storyboard();
            sb.AddSlideFromLeft(seconds, element.ActualWidth, keepMargin: keepMargins);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides an element out to the left
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The amount of seconds it should take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargins = true)
        {
            if (seconds == 0) element.Visibility = Visibility.Hidden;
            Storyboard sb = new Storyboard();
            sb.AddSlideToLeft(seconds, element.ActualWidth, keepMargin: keepMargins);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides an element out to the left
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The amount of seconds it should take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargins = true)
        {
            if (seconds == 0) element.Visibility = Visibility.Hidden;
            Storyboard sb = new Storyboard();
            sb.AddSlideToRight(seconds, element.ActualWidth, keepMargin: keepMargins);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        #region Slide In From Bottom

        /// <summary>
        /// Slides an element in from the bottom
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same height during animation</param>
        /// <param name="height">The animation height to animate to. If not specified the elements height is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromBottomAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            if (seconds == 0) element.Visibility = Visibility.Hidden;
            Storyboard sb = new Storyboard();
            sb.AddSlideFromBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out to the bottom
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same height during animation</param>
        /// <param name="height">The animation height to animate to. If not specified the elements height is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToBottomAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            if (seconds == 0) element.Visibility = Visibility.Hidden;
            Storyboard sb = new Storyboard();
            sb.AddSlideToBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)(seconds * 1000));
            element.Visibility = Visibility.Hidden;
        }

        #endregion

    }
}
