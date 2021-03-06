﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace WpfPhotoFrame.Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private List<PhotoFrameSource> frameList = new List<PhotoFrameSource>
        {
            new PhotoFrameSource{ Source = "pack://application:,,,/WpfPhotoFrame.Demo;component/Images/Pf03.png", CornerSizes=new DoubleCollection(){ 120,120 } },
            new PhotoFrameSource{ Source = "pack://application:,,,/WpfPhotoFrame.Demo;component/Images/TestFrame.png", CornerSizes=new DoubleCollection(){ 60, 60 } },
            new PhotoFrameSource{ Source = "http://www.w3school.com.cn/i/border.png", CornerSizes=new DoubleCollection(){ 26 } },
        };
        public List<PhotoFrameSource> FrameList
        {
            get => frameList;
            set
            {
                if (frameList != value)
                {
                    frameList = value;
                    RaisePropertyChanged(nameof(FrameList));
                }
            }
        }

        private List<PhotoFrameMode> modeList = new List<PhotoFrameMode>
        {
            PhotoFrameMode.Internal, PhotoFrameMode.Intermediate, PhotoFrameMode.Outernal
        };
        public List<PhotoFrameMode> ModeList
        {
            get => modeList;
            set
            {
                if (modeList != value)
                {
                    modeList = value;
                    RaisePropertyChanged(nameof(ModeList));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
