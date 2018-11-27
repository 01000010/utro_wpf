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
    /// Interaction logic for TextEntryControl.xaml
    /// </summary>
    public partial class TextEntryControl : UserControl
    {

        public GridLength LabelWidth
        {
            get { return (GridLength)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(TextEntryControl), new PropertyMetadata(GridLength.Auto, LabelWidthChangedCallback));

        /// <summary>
        /// Called when the label width has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void LabelWidthChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                (d as TextEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch
            {
                (d as TextEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        public TextEntryControl()
        {
            InitializeComponent();
        }
    }
}
