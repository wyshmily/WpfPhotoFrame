using System.Windows;
using System.Windows.Controls;

namespace WpfPhotoFrame
{
    internal class PhotoFrameChrome : Control
    {
        static PhotoFrameChrome()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PhotoFrameChrome), new FrameworkPropertyMetadata(typeof(PhotoFrameChrome)));
        }
    }
}
