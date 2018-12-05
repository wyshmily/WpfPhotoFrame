using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfPhotoFrame
{
    public class PhotoFrameDecorator : Control
    {
        static PhotoFrameDecorator()
        {
            Image.SourceProperty.AddOwner(typeof(PhotoFrameDecorator));
            PhotoFrame.CornerSizeProperty.AddOwner(typeof(PhotoFrameDecorator));
            PhotoFrame.ScaleProperty.AddOwner(typeof(PhotoFrameDecorator));
            PhotoFrame.ModeProperty.AddOwner(typeof(PhotoFrameDecorator));
        }

        /// <summary>
        /// ImageSource
        /// </summary>
        public ImageSource Source
        {
            get => (ImageSource)GetValue(Image.SourceProperty);
            set => SetValue(Image.SourceProperty, value);
        }

        /// <summary>
        /// Size of Corner, desided by the source picture
        /// </summary>
        public double CornerSize
        {
            get => (double)GetValue(PhotoFrame.CornerSizeProperty);
            set => SetValue(PhotoFrame.CornerSizeProperty, value);
        }

        /// <summary>
        /// zoom scale, on top of the original image size
        /// </summary>
        public double Scale
        {
            get => (double)GetValue(PhotoFrame.ScaleProperty);
            set => SetValue(PhotoFrame.ScaleProperty, value);
        }

        /// <summary>
        /// mode, internal, outernal or intermediate
        /// </summary>
        public PhotoFrameMode Mode
        {
            get => (PhotoFrameMode)GetValue(PhotoFrame.ModeProperty);
            set => SetValue(PhotoFrame.ModeProperty, value);
        }

        private Adorner adorner;

        public PhotoFrameDecorator()
        {
            Loaded += PhotoFrameDecorator_Loaded;
            Unloaded += PhotoFrameDecorator_Unloaded;
        }

        private void PhotoFrameDecorator_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.adorner == null)
            {
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);

                if (adornerLayer != null)
                {
                    this.adorner = new PhotoFrameAdorner(this);
                    adornerLayer.Add(this.adorner);
                }
            }
        }

        private void PhotoFrameDecorator_Unloaded(object sender, RoutedEventArgs e)
        {
            if (this.adorner != null)
            {
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
                if (adornerLayer != null)
                {
                    adornerLayer.Remove(this.adorner);
                }

                this.adorner = null;
            }
        }
    }
}
