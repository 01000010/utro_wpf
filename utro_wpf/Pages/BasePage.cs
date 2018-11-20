using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace utro_wpf
{
    /// <summary>
    /// A base page for all the pages to gain functionality    
    /// </summary>
    public class BasePage<VM> : Page where VM : BaseViewModel, new()
    {
        #region Private Member

        /// <summary>
        /// The view model associated with this
        /// </summary>
        private VM mViewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// The animation that gets trigged when a page is loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeFromRight;

        /// <summary>
        /// The animation that gets trigged when a page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeToLeft;

        /// <summary>
        /// The amount of time taken by the animations
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        public VM ViewModel
        {
            get { return mViewModel; }
            set
            {
                // If nothing has changed about the page return
                if (mViewModel == value) return;
                // Otherwise update the value
                mViewModel = value;
                // Set the data context for this page
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            // If there is an animatino in place collapse the visibility
            if (PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            // Listen for the page loading
            Loaded += BasePage_Loaded;

            // By default make a new viewmodel
            DataContext = new VM();
        }

        #endregion

        #region Animation Load / Unload

        /// <summary>
        /// Once the page is loaded perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }

        /// <summary>
        /// Animates the page
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None) return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeFromRight:
                    await this.SlideAndFadeInFromRight(SlideSeconds);
                    break;
            }
        }

        /// <summary>
        /// Animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            if (PageUnloadAnimation == PageAnimation.None) return;

            switch(PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeToLeft:
                    await this.SlideAndFadeOutToLeft(SlideSeconds);
                    break;
            }
        }

        #endregion
    }
}
