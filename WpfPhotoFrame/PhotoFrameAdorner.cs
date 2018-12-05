using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfPhotoFrame
{
    internal class PhotoFrameAdorner : Adorner
    {
        private readonly VisualCollection visuals;
        private readonly PhotoFrameChrome chrome;
        protected override int VisualChildrenCount => this.visuals.Count;

        public PhotoFrameAdorner(FrameworkElement adornedElement) : base(adornedElement)
        {
            this.chrome = new PhotoFrameChrome { DataContext = adornedElement };
            this.visuals = new VisualCollection(this) { this.chrome };
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            this.chrome.Arrange(new Rect(arrangeBounds));
            return arrangeBounds;
        }

        protected override Visual GetVisualChild(int index) => this.visuals[index];
    }
}
