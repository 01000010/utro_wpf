using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace utro_wpf
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Constructor

        /// <summary>
        /// The default constructor
        /// </summary>
        public PageHost()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Property

        /// <summary>
        /// Current page to show in the PageHost
        /// </summary>
        public BasePage CurrentPage
        {
            get { return (BasePage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        /// <summary>
        ///  Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged)); 

        #endregion

        #region Property Changed Events

        /// <summary>
        /// Called when the current page value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Get them frames
            Frame newPageFrame = (d as PageHost).NewPage;
            Frame oldPageFrame = (d as PageHost).OldPage;
            // Old contents
            object oldPageContent = newPageFrame.Content;
            // Remove current page from new page frame
            newPageFrame.Content = null;
            // Move the previous page content into the old one
            oldPageFrame.Content = oldPageContent;
            
            // Animate out the previous page when the loaded even fires
            if (oldPageContent is BasePage oldPage)
            {
                // Animate out the old page
                oldPage.ShouldAnimateOut = true;

                // Remove the contents of the oldpage as soon as it has animated out
                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null); 
                });
            }

            // Set the new page content
            newPageFrame.Content = e.NewValue;
        }
        
        #endregion
    }
}
