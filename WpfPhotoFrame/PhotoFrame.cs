using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfPhotoFrame
{
    public class PhotoFrame : Control
    {
        static PhotoFrame()
        {
            Image.SourceProperty.AddOwner(typeof(PhotoFrame), new FrameworkPropertyMetadata(UpdatePhotoFrame));
        }

        private Adorner adorner;

        public PhotoFrame()
        {
            Loaded += PhotoFrameDecorator_Loaded;
            Unloaded += PhotoFrameDecorator_Unloaded;
            SizeChanged += PhotoFrame_SizeChanged;
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

        private void PhotoFrame_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdatePhotoFrame(sender as DependencyObject, new DependencyPropertyChangedEventArgs());
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
        public static readonly DependencyProperty CornerSizeProperty = DependencyProperty.Register("CornerSize", typeof(double), typeof(PhotoFrame), new FrameworkPropertyMetadata(UpdatePhotoFrame));
        public double CornerSize
        {
            get => (double)GetValue(CornerSizeProperty);
            set => SetValue(CornerSizeProperty, value);
        }

        /// <summary>
        /// zoom scale, on top of the original image size
        /// </summary>
        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register("Scale", typeof(double), typeof(PhotoFrame), new PropertyMetadata(1.0, UpdatePhotoFrame));
        public double Scale
        {
            get => (double)GetValue(ScaleProperty);
            set => SetValue(ScaleProperty, value);
        }

        /// <summary>
        /// mode, internal, outernal or intermediate
        /// </summary>
        public static readonly DependencyProperty ModeProperty = DependencyProperty.Register("Mode", typeof(PhotoFrameMode), typeof(PhotoFrame), new PropertyMetadata(PhotoFrameMode.Internal, UpdatePhotoFrame));
        public PhotoFrameMode Mode
        {
            get => (PhotoFrameMode)GetValue(ModeProperty);
            set => SetValue(ModeProperty, value);
        }

        /// <summary>
        /// corner size after scale
        /// </summary>
        public static readonly DependencyProperty ScaledCornerSizeProperty = DependencyProperty.Register("ScaledCornerSize", typeof(double), typeof(PhotoFrame));
        public double ScaledCornerSize
        {
            get => (double)GetValue(ScaledCornerSizeProperty);
            private set => SetValue(ScaledCornerSizeProperty, value);
        }

        /// <summary>
        /// overflow margin decided by ModeProperty
        /// </summary>
        public static readonly DependencyProperty OverflowMarginProperty = DependencyProperty.Register("OverflowMargin", typeof(double), typeof(PhotoFrame));
        public double OverflowMargin
        {
            get => (double)GetValue(OverflowMarginProperty);
            private set => SetValue(OverflowMarginProperty, value);
        }

        /// <summary>
        /// 剩余边宽
        /// </summary>
        public static readonly DependencyProperty SideWidthProperty = DependencyProperty.Register("SideWidth", typeof(double), typeof(PhotoFrame));
        public double SideWidth
        {
            get => (double)GetValue(SideWidthProperty);
            private set => SetValue(SideWidthProperty, value);
        }

        /// <summary>
        /// 剩余边高
        /// </summary>
        public static readonly DependencyProperty SideHeightProperty = DependencyProperty.Register("SideHeight", typeof(double), typeof(PhotoFrame));
        public double SideHeight
        {
            get => (double)GetValue(SideHeightProperty);
            private set => SetValue(SideHeightProperty, value);
        }

        /// <summary>
        /// 图片显示宽度
        /// </summary>
        public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register("ImageWidth", typeof(double), typeof(PhotoFrame));
        public double ImageWidth
        {
            get => (double)GetValue(ImageWidthProperty);
            private set => SetValue(ImageWidthProperty, value);
        }

        /// <summary>
        /// 图片显示高度
        /// </summary>
        public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register("ImageHeight", typeof(double), typeof(PhotoFrame));
        public double ImageHeight
        {
            get => (double)GetValue(ImageHeightProperty);
            private set => SetValue(ImageHeightProperty, value);
        }

        /// <summary>
        /// ViewPort For TopLeft
        /// </summary>
        public static readonly DependencyProperty ViewPortTopLeftProperty = DependencyProperty.Register("ViewPortTopLeft", typeof(Rect), typeof(PhotoFrame));
        public Rect ViewPortTopLeft
        {
            get => (Rect)GetValue(ViewPortTopLeftProperty);
            private set => SetValue(ViewPortTopLeftProperty, value);
        }

        /// <summary>
        /// ViewPort For TopRight
        /// </summary>
        public static readonly DependencyProperty ViewPortTopRightProperty = DependencyProperty.Register("ViewPortTopRight", typeof(Rect), typeof(PhotoFrame));
        public Rect ViewPortTopRight
        {
            get => (Rect)GetValue(ViewPortTopRightProperty);
            private set => SetValue(ViewPortTopRightProperty, value);
        }

        /// <summary>
        /// ViewPort For BottomLeft
        /// </summary>
        public static readonly DependencyProperty ViewPortBottomLeftProperty = DependencyProperty.Register("ViewPortBottomLeft", typeof(Rect), typeof(PhotoFrame));
        public Rect ViewPortBottomLeft
        {
            get => (Rect)GetValue(ViewPortBottomLeftProperty);
            private set => SetValue(ViewPortBottomLeftProperty, value);
        }

        /// <summary>
        /// ViewPort For BottomRight
        /// </summary>
        public static readonly DependencyProperty ViewPortBottomRightProperty = DependencyProperty.Register("ViewPortBottomRight", typeof(Rect), typeof(PhotoFrame));
        public Rect ViewPortBottomRight
        {
            get => (Rect)GetValue(ViewPortBottomRightProperty);
            private set => SetValue(ViewPortBottomRightProperty, value);
        }

        /// <summary>
        /// ViewPort For Top and Bottom
        /// </summary>
        public static readonly DependencyProperty ViewPortHorizontalProperty = DependencyProperty.Register("ViewPortHorizontal", typeof(Rect), typeof(PhotoFrame));
        public Rect ViewPortHorizontal
        {
            get => (Rect)GetValue(ViewPortHorizontalProperty);
            private set => SetValue(ViewPortHorizontalProperty, value);
        }

        /// <summary>
        /// ViewPort For Left and Right
        /// </summary>
        public static readonly DependencyProperty ViewPortVerticalProperty = DependencyProperty.Register("ViewPortVertical", typeof(Rect), typeof(PhotoFrame));
        public Rect ViewPortVertical
        {
            get => (Rect)GetValue(ViewPortVerticalProperty);
            private set => SetValue(ViewPortVerticalProperty, value);
        }

        /// <summary>
        /// Margin For Top to Position the image
        /// </summary>
        public static readonly DependencyProperty MarginTopProperty = DependencyProperty.Register("MarginTop", typeof(Thickness), typeof(PhotoFrame));
        public Thickness MarginTop
        {
            get => (Thickness)GetValue(MarginTopProperty);
            private set => SetValue(MarginTopProperty, value);
        }

        /// <summary>
        /// Margin For Bottom to Position the image
        /// </summary>
        public static readonly DependencyProperty MarginBottomProperty = DependencyProperty.Register("MarginBottom", typeof(Thickness), typeof(PhotoFrame));
        public Thickness MarginBottom
        {
            get => (Thickness)GetValue(MarginBottomProperty);
            private set => SetValue(MarginBottomProperty, value);
        }

        /// <summary>
        /// Margin For Left to Position the image
        /// </summary>
        public static readonly DependencyProperty MarginLeftProperty = DependencyProperty.Register("MarginLeft", typeof(Thickness), typeof(PhotoFrame));
        public Thickness MarginLeft
        {
            get => (Thickness)GetValue(MarginLeftProperty);
            private set => SetValue(MarginLeftProperty, value);
        }

        /// <summary>
        /// Margin For Right to Position the image
        /// </summary>
        public static readonly DependencyProperty MarginRightProperty = DependencyProperty.Register("MarginRight", typeof(Thickness), typeof(PhotoFrame));
        public Thickness MarginRight
        {
            get => (Thickness)GetValue(MarginRightProperty);
            private set => SetValue(MarginRightProperty, value);
        }

        /// <summary>
        /// Layout the PhotoFrame
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void UpdatePhotoFrame(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PhotoFrame pf && pf.CornerSize > 0 && pf.Source is BitmapSource bitmapSource && pf.ActualWidth > 0 && pf.ActualHeight > 0)
            {
                pf.ScaledCornerSize = pf.Scale * pf.CornerSize;

                switch (pf.Mode)
                {
                    case PhotoFrameMode.Internal:
                        pf.OverflowMargin = 0;
                        break;
                    case PhotoFrameMode.Outernal:
                        pf.OverflowMargin = -pf.ScaledCornerSize;
                        break;
                    case PhotoFrameMode.Intermediate:
                        pf.OverflowMargin = -pf.ScaledCornerSize / 2;
                        break;
                }

                pf.ImageWidth = bitmapSource.PixelWidth;
                pf.ImageHeight = bitmapSource.PixelHeight;

                double scaledPixelWidth = bitmapSource.PixelWidth * pf.Scale;
                double scaledPixelHeight = bitmapSource.PixelHeight * pf.Scale;

                pf.ViewPortTopLeft = new Rect(0, 0, scaledPixelWidth, scaledPixelHeight);
                pf.ViewPortTopRight = new Rect(pf.ScaledCornerSize - scaledPixelWidth, 0, scaledPixelWidth, scaledPixelHeight);
                pf.ViewPortBottomLeft = new Rect(0, pf.ScaledCornerSize - scaledPixelHeight, scaledPixelWidth, scaledPixelHeight);
                pf.ViewPortBottomRight = new Rect(pf.ScaledCornerSize - scaledPixelWidth, pf.ScaledCornerSize - scaledPixelHeight, scaledPixelWidth, scaledPixelHeight);

                pf.SideWidth = bitmapSource.PixelWidth - pf.CornerSize * 2;
                pf.SideHeight = bitmapSource.PixelHeight - pf.CornerSize * 2;

                double sideWidth = pf.ActualWidth - pf.OverflowMargin * 2 - pf.ScaledCornerSize * 2;
                double horizontalTileCount = Math.Ceiling(sideWidth / pf.SideWidth / pf.Scale);
                if (horizontalTileCount > 0)
                {
                    pf.ViewPortHorizontal = new Rect(0, 0, sideWidth / horizontalTileCount, pf.ScaledCornerSize);
                    pf.MarginTop = new Thickness(-pf.CornerSize, 0, 0, 0);
                    pf.MarginBottom = new Thickness(-pf.CornerSize, pf.CornerSize - pf.ImageHeight, 0, 0);
                }
                else
                    pf.ViewPortHorizontal = new Rect(0, 0, 0, 0);

                double sideHeight = pf.ActualHeight - pf.OverflowMargin * 2 - pf.ScaledCornerSize * 2;
                double verticalTileCount = Math.Ceiling(sideHeight / pf.SideHeight / pf.Scale);
                if (verticalTileCount > 0)
                {
                    pf.ViewPortVertical = new Rect(0, 0, pf.ScaledCornerSize, sideHeight / verticalTileCount);
                    pf.MarginLeft = new Thickness(0, -pf.CornerSize, 0, 0);
                    pf.MarginRight = new Thickness(pf.CornerSize - pf.ImageWidth, -pf.CornerSize, 0, 0);
                }
                else
                    pf.ViewPortVertical = new Rect(0, 0, 0, 0);
            }
        }
    }
}
