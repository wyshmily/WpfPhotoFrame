using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfPhotoFrame
{
    public class PhotoFrame : ContentControl
    {
        static PhotoFrame()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PhotoFrame), new FrameworkPropertyMetadata(typeof(PhotoFrame)));
            Image.SourceProperty.AddOwner(typeof(PhotoFrame), new FrameworkPropertyMetadata(UpdatePhotoFrame));
        }

        public PhotoFrame()
        {
            SizeChanged += PhotoFrame_SizeChanged;
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
        /// Support different corner sizes, CornerSizeProperty is ignored if this property is setted, 
        /// </summary>
        public static readonly DependencyProperty CornerSizesProperty = DependencyProperty.Register("CornerSizes", typeof(DoubleCollection), typeof(PhotoFrame), new FrameworkPropertyMetadata(UpdatePhotoFrame));
        public DoubleCollection CornerSizes
        {
            get => (DoubleCollection)GetValue(CornerSizesProperty);
            set => SetValue(CornerSizesProperty, value);
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
        /// size of topleft corner
        /// </summary>
        public static readonly DependencyProperty TopLeftSizeProperty = DependencyProperty.Register("TopLeftSize", typeof(Size), typeof(PhotoFrame));
        public Size TopLeftSize
        {
            get => (Size)GetValue(TopLeftSizeProperty);
            private set => SetValue(TopLeftSizeProperty, value);
        }

        /// <summary>
        /// size of topright corner
        /// </summary>
        public static readonly DependencyProperty TopRightSizeProperty = DependencyProperty.Register("TopRightSize", typeof(Size), typeof(PhotoFrame));
        public Size TopRightSize
        {
            get => (Size)GetValue(TopRightSizeProperty);
            private set => SetValue(TopRightSizeProperty, value);
        }

        /// <summary>
        /// size of bottomright corner
        /// </summary>
        public static readonly DependencyProperty BottomRightSizeProperty = DependencyProperty.Register("BottomRightSize", typeof(Size), typeof(PhotoFrame));
        public Size BottomRightSize
        {
            get => (Size)GetValue(BottomRightSizeProperty);
            private set => SetValue(BottomRightSizeProperty, value);
        }

        /// <summary>
        /// size of bottomleft corner
        /// </summary>
        public static readonly DependencyProperty BottomLeftSizeProperty = DependencyProperty.Register("BottomLeftSize", typeof(Size), typeof(PhotoFrame));
        public Size BottomLeftSize
        {
            get => (Size)GetValue(BottomLeftSizeProperty);
            private set => SetValue(BottomLeftSizeProperty, value);
        }

        /// <summary>
        /// top height after scale
        /// </summary>
        public static readonly DependencyProperty TopHeightProperty = DependencyProperty.Register("TopHeight", typeof(double), typeof(PhotoFrame));
        public double TopHeight
        {
            get => (double)GetValue(TopHeightProperty);
            private set => SetValue(TopHeightProperty, value);
        }

        /// <summary>
        /// bottom height after scale
        /// </summary>
        public static readonly DependencyProperty BottomHeightProperty = DependencyProperty.Register("BottomHeight", typeof(double), typeof(PhotoFrame));
        public double BottomHeight
        {
            get => (double)GetValue(BottomHeightProperty);
            private set => SetValue(BottomHeightProperty, value);
        }

        /// <summary>
        /// left width after scale
        /// </summary>
        public static readonly DependencyProperty LeftWidthProperty = DependencyProperty.Register("LeftWidth", typeof(double), typeof(PhotoFrame));
        public double LeftWidth
        {
            get => (double)GetValue(LeftWidthProperty);
            private set => SetValue(LeftWidthProperty, value);
        }

        /// <summary>
        /// right width after scale
        /// </summary>
        public static readonly DependencyProperty RightWidthProperty = DependencyProperty.Register("RightWidth", typeof(double), typeof(PhotoFrame));
        public double RightWidth
        {
            get => (double)GetValue(RightWidthProperty);
            private set => SetValue(RightWidthProperty, value);
        }

        /// <summary>
        /// overflow margin decided by ModeProperty
        /// </summary>
        public static readonly DependencyProperty OverflowMarginProperty = DependencyProperty.Register("OverflowMargin", typeof(Thickness), typeof(PhotoFrame));
        public Thickness OverflowMargin
        {
            get => (Thickness)GetValue(OverflowMarginProperty);
            private set => SetValue(OverflowMarginProperty, value);
        }

        /// <summary>
        /// top size of after crop before scale
        /// </summary>
        public static readonly DependencyProperty TopSizeProperty = DependencyProperty.Register("TopSize", typeof(Size), typeof(PhotoFrame));
        public Size TopSize
        {
            get => (Size)GetValue(TopSizeProperty);
            private set => SetValue(TopSizeProperty, value);
        }

        /// <summary>
        /// bottom size of after crop before scale
        /// </summary>
        public static readonly DependencyProperty BottomSizeProperty = DependencyProperty.Register("BottomSize", typeof(Size), typeof(PhotoFrame));
        public Size BottomSize
        {
            get => (Size)GetValue(BottomSizeProperty);
            private set => SetValue(BottomSizeProperty, value);
        }

        /// <summary>
        /// left size of after crop before scale
        /// </summary>
        public static readonly DependencyProperty LeftSizeProperty = DependencyProperty.Register("LeftSize", typeof(Size), typeof(PhotoFrame));
        public Size LeftSize
        {
            get => (Size)GetValue(LeftSizeProperty);
            private set => SetValue(LeftSizeProperty, value);
        }

        /// <summary>
        /// right size of after crop before scale
        /// </summary>
        public static readonly DependencyProperty RightSizeProperty = DependencyProperty.Register("RightSize", typeof(Size), typeof(PhotoFrame));
        public Size RightSize
        {
            get => (Size)GetValue(RightSizeProperty);
            private set => SetValue(RightSizeProperty, value);
        }

        /// <summary>
        /// Image Width after scale
        /// </summary>
        public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register("ImageWidth", typeof(double), typeof(PhotoFrame));
        public double ImageWidth
        {
            get => (double)GetValue(ImageWidthProperty);
            private set => SetValue(ImageWidthProperty, value);
        }

        /// <summary>
        /// Image Height after scale
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
        /// ViewPort For Top 
        /// </summary>
        public static readonly DependencyProperty ViewPortTopProperty = DependencyProperty.Register("ViewPortTop", typeof(Rect), typeof(PhotoFrame));
        public Rect ViewPortTop
        {
            get => (Rect)GetValue(ViewPortTopProperty);
            private set => SetValue(ViewPortTopProperty, value);
        }

        /// <summary>
        /// ViewPort For Bottom 
        /// </summary>
        public static readonly DependencyProperty ViewPortBottomProperty = DependencyProperty.Register("ViewPortBottom", typeof(Rect), typeof(PhotoFrame));
        public Rect ViewPortBottom
        {
            get => (Rect)GetValue(ViewPortBottomProperty);
            private set => SetValue(ViewPortBottomProperty, value);
        }

        /// <summary>
        /// ViewPort For Left 
        /// </summary>
        public static readonly DependencyProperty ViewPortLeftProperty = DependencyProperty.Register("ViewPortLeft", typeof(Rect), typeof(PhotoFrame));
        public Rect ViewPortLeft
        {
            get => (Rect)GetValue(ViewPortLeftProperty);
            private set => SetValue(ViewPortLeftProperty, value);
        }

        /// <summary>
        /// ViewPort For Right 
        /// </summary>
        public static readonly DependencyProperty ViewPortRightProperty = DependencyProperty.Register("ViewPortRight", typeof(Rect), typeof(PhotoFrame));
        public Rect ViewPortRight
        {
            get => (Rect)GetValue(ViewPortRightProperty);
            private set => SetValue(ViewPortRightProperty, value);
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
            if (d is PhotoFrame pf && pf.CornerSizes?.Count > 0 && pf.Source is BitmapSource bitmapSource && pf.ActualWidth > 0 && pf.ActualHeight > 0)
            {
                Size topLeftSize = new Size(pf.CornerSizes[0], pf.CornerSizes[0]);
                Size topRightSize = new Size(pf.CornerSizes[0], pf.CornerSizes[0]);
                Size bottomRightSize = new Size(pf.CornerSizes[0], pf.CornerSizes[0]);
                Size bottomLeftSize = new Size(pf.CornerSizes[0], pf.CornerSizes[0]);

                if (pf.CornerSizes.Count >= 2)
                {
                    topLeftSize.Height = pf.CornerSizes[1];
                    topRightSize.Height = pf.CornerSizes[1];
                    bottomRightSize.Height = pf.CornerSizes[1];
                    bottomLeftSize.Height = pf.CornerSizes[1];
                }
                if (pf.CornerSizes.Count >= 4)
                {
                    topRightSize = new Size(pf.CornerSizes[2], pf.CornerSizes[3]);
                    bottomLeftSize = new Size(pf.CornerSizes[2], pf.CornerSizes[3]);
                }
                if (pf.CornerSizes.Count >= 6)
                    bottomRightSize = new Size(pf.CornerSizes[4], pf.CornerSizes[5]);
                if (pf.CornerSizes.Count >= 8)
                    bottomLeftSize = new Size(pf.CornerSizes[6], pf.CornerSizes[7]);

                pf.TopLeftSize = new Size(topLeftSize.Width * pf.Scale, topLeftSize.Height * pf.Scale);
                pf.TopRightSize = new Size(topRightSize.Width * pf.Scale, topRightSize.Height * pf.Scale); ;
                pf.BottomRightSize = new Size(bottomRightSize.Width * pf.Scale, bottomRightSize.Height * pf.Scale);
                pf.BottomLeftSize = new Size(bottomLeftSize.Width * pf.Scale, bottomLeftSize.Height * pf.Scale);

                switch (pf.Mode)
                {
                    case PhotoFrameMode.Internal:
                        pf.OverflowMargin = new Thickness(0);
                        break;
                    case PhotoFrameMode.Outernal:
                        pf.OverflowMargin = new Thickness(-new[] { pf.TopLeftSize.Width, pf.TopRightSize.Width, pf.BottomRightSize.Width, pf.BottomLeftSize.Width }.Max(), -new[] { pf.TopLeftSize.Height, pf.TopRightSize.Height, pf.BottomRightSize.Height, pf.BottomLeftSize.Height }.Max(), -new[] { pf.TopLeftSize.Width, pf.TopRightSize.Width, pf.BottomRightSize.Width, pf.BottomLeftSize.Width }.Max(), -new[] { pf.TopLeftSize.Height, pf.TopRightSize.Height, pf.BottomRightSize.Height, pf.BottomLeftSize.Height }.Max());
                        break;
                    case PhotoFrameMode.Intermediate:
                        pf.OverflowMargin = new Thickness(-new[] { pf.TopLeftSize.Width, pf.TopRightSize.Width, pf.BottomRightSize.Width, pf.BottomLeftSize.Width }.Max() / 2, -new[] { pf.TopLeftSize.Height, pf.TopRightSize.Height, pf.BottomRightSize.Height, pf.BottomLeftSize.Height }.Max() / 2, -new[] { pf.TopLeftSize.Width, pf.TopRightSize.Width, pf.BottomRightSize.Width, pf.BottomLeftSize.Width }.Max() / 2, -new[] { pf.TopLeftSize.Height, pf.TopRightSize.Height, pf.BottomRightSize.Height, pf.BottomLeftSize.Height }.Max() / 2);
                        break;
                }

                pf.ImageWidth = bitmapSource.PixelWidth;
                pf.ImageHeight = bitmapSource.PixelHeight;

                double scaledPixelWidth = bitmapSource.PixelWidth * pf.Scale;
                double scaledPixelHeight = bitmapSource.PixelHeight * pf.Scale;

                pf.ViewPortTopLeft = new Rect(0, 0, scaledPixelWidth, scaledPixelHeight);
                pf.ViewPortTopRight = new Rect(pf.TopRightSize.Width - scaledPixelWidth, 0, scaledPixelWidth, scaledPixelHeight);
                pf.ViewPortBottomLeft = new Rect(0, pf.BottomLeftSize.Height - scaledPixelHeight, scaledPixelWidth, scaledPixelHeight);
                pf.ViewPortBottomRight = new Rect(pf.BottomRightSize.Width - scaledPixelWidth, pf.BottomRightSize.Height - scaledPixelHeight, scaledPixelWidth, scaledPixelHeight);

                pf.TopHeight = Math.Min(pf.TopLeftSize.Height, pf.TopRightSize.Height);
                pf.BottomHeight = Math.Min(pf.BottomLeftSize.Height, pf.BottomRightSize.Height);
                pf.LeftWidth = Math.Min(pf.TopLeftSize.Width, pf.BottomLeftSize.Width);
                pf.RightWidth = Math.Min(pf.TopRightSize.Width, pf.BottomRightSize.Width);

                pf.TopSize = new Size(Math.Max(bitmapSource.PixelWidth - topLeftSize.Width - topRightSize.Width, 0), Math.Min(topLeftSize.Height, topRightSize.Height));
                pf.BottomSize = new Size(Math.Max(bitmapSource.PixelWidth - bottomLeftSize.Width - bottomRightSize.Width, 0), Math.Min(bottomLeftSize.Height, bottomRightSize.Height));
                pf.LeftSize = new Size(Math.Min(topLeftSize.Width, bottomLeftSize.Width), Math.Max(bitmapSource.PixelHeight - topLeftSize.Height - bottomLeftSize.Height, 0));
                pf.RightSize = new Size(Math.Min(topRightSize.Width, bottomRightSize.Width), Math.Max(bitmapSource.PixelHeight - topRightSize.Height - bottomRightSize.Height, 0));

                double topSideWidth = pf.ActualWidth - pf.OverflowMargin.Left - pf.OverflowMargin.Right - pf.TopLeftSize.Width - pf.TopRightSize.Width;
                double topTileCount = Math.Round(topSideWidth / pf.TopSize.Width / pf.Scale, 0);
                if (topTileCount > 0)
                {
                    pf.ViewPortTop = new Rect(0, 0, topSideWidth / topTileCount, pf.TopHeight);
                    pf.MarginTop = new Thickness(-topLeftSize.Width, 0, 0, 0);
                }
                else
                    pf.ViewPortTop = new Rect(0, 0, 0, 0);

                double bottomSideWidth = pf.ActualWidth - pf.OverflowMargin.Left - pf.OverflowMargin.Right - pf.BottomLeftSize.Width - pf.BottomRightSize.Width;
                double bottomTileCount = Math.Round(bottomSideWidth / pf.BottomSize.Width / pf.Scale, 0);
                if (bottomTileCount > 0)
                {
                    pf.ViewPortBottom = new Rect(0, 0, bottomSideWidth / bottomTileCount, pf.BottomHeight);
                    pf.MarginBottom = new Thickness(-topLeftSize.Width, pf.BottomSize.Height - pf.ImageHeight, 0, 0);
                }
                else
                    pf.ViewPortBottom = new Rect(0, 0, 0, 0);

                double leftSideHeight = pf.ActualHeight - pf.OverflowMargin.Top - pf.OverflowMargin.Bottom - pf.TopLeftSize.Height - pf.BottomLeftSize.Height;
                double leftTileCount = Math.Round(leftSideHeight / pf.LeftSize.Height / pf.Scale, 0);
                if (leftTileCount > 0)
                {
                    pf.ViewPortLeft = new Rect(0, 0, pf.LeftWidth, leftSideHeight / leftTileCount);
                    pf.MarginLeft = new Thickness(0, -topLeftSize.Height, 0, 0);
                }
                else
                    pf.ViewPortLeft = new Rect(0, 0, 0, 0);

                double rightSideHeight = pf.ActualHeight - pf.OverflowMargin.Top - pf.OverflowMargin.Bottom - pf.TopRightSize.Height - pf.BottomRightSize.Height;
                double rightTileCount = Math.Round(rightSideHeight / pf.RightSize.Height / pf.Scale, 0);
                if (rightTileCount > 0)
                {
                    pf.ViewPortRight = new Rect(0, 0, pf.RightWidth, rightSideHeight / rightTileCount);
                    pf.MarginRight = new Thickness(pf.RightSize.Width - pf.ImageWidth, -topRightSize.Height, 0, 0);
                }
                else
                    pf.ViewPortRight = new Rect(0, 0, 0, 0);
            }
        }
    }
}
