# WpfPhotoFrame
A easy way to apply a PhotoFrame to anything in WPF.

#### Use a Frame Image, like:

<img src="https://github.com/wyshmily/WpfPhotoFrame/blob/master/WpfPhotoFrame.Demo/Images/TestFrame.png" width="90">

#### Apply it to just anything(a photo for example):
<img src="https://github.com/wyshmily/WpfPhotoFrame/blob/master/WpfPhotoFrame.Demo/Images/jangye.jpeg" width="400">

#### Poduces:
<img src="https://github.com/wyshmily/WpfPhotoFrame/blob/master/WpfPhotoFrame.Demo/Images/result.png" width="400">

#### Usage:
````xaml

<!--xmlns:pf="http://wpf.wyshmily/photoframe"-->

<pf:PhotoFrame Source="Images/TestFrame.png" CornerSize="60" Scale="0.4">
    <Image Source="Images/jangye.jpeg" Width="400" />
</pf:PhotoFrame>

````
