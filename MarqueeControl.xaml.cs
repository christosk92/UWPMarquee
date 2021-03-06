using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// ユーザー コントロールの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234236 を参照してください

namespace UWPMarquee
{
    public sealed partial class MarqueeControl : UserControl
    {
        public static readonly DependencyProperty SpacingProperty = DependencyProperty.Register("Spacing", 
            typeof(double), typeof(MarqueeControl), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty SecondProperty = DependencyProperty.Register("Second", 
            typeof(FrameworkElement), typeof(MarqueeControl), new PropertyMetadata(default(FrameworkElement)));
        public static readonly DependencyProperty FirstProperty = DependencyProperty.Register("First", 
            typeof(FrameworkElement), typeof(MarqueeControl), new PropertyMetadata(default(FrameworkElement)));
        public MarqueeControl()
        {
            this.InitializeComponent();
        }

        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public FrameworkElement Second
        {
            get { return (FrameworkElement)GetValue(SecondProperty); }
            set { SetValue(SecondProperty, value); }
        }

        public FrameworkElement First
        {
            get { return (FrameworkElement)GetValue(FirstProperty); }
            set { SetValue(FirstProperty, value); }
        }

        private void Stack_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            txtKron2.Margin = new Thickness(txtKron.ActualWidth + Spacing, 0, 0, 0);
            SbFr.From = 0;
            SbFr.To = -txtKron.ActualWidth - Spacing;

            SbFr2.From = 0;
            SbFr2.To = -txtKron2.Margin.Left;
            if (txtKron.ActualWidth >= Grd.ActualWidth)
            {
                slide.Begin();
                txtKron2.Visibility = Visibility.Visible;
            }
            else
            {
                slide.Stop();
                txtKron2.Visibility = Visibility.Collapsed;
            }
        }
    }
}
