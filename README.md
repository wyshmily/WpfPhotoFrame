# WpfPhotoFrame
A easy way to apply a PhotoFrame to anything in WPF.

#### Use a Frame Image, like:
<img src="https://github.com/wyshmily/WpfPhotoFrame/blob/master/WpfPhotoFrame.Demo/Images/TestFrame.png" width="90">

#### Apply it to just anything(a photo for example):
<img src="https://github.com/wyshmily/WpfPhotoFrame/blob/master/WpfPhotoFrame.Demo/Images/jangye.jpeg" width="400">

#### Poduces:
<img src="https://github.com/wyshmily/WpfPhotoFrame/blob/master/WpfPhotoFrame.Demo/Images/result.png" width="400">
<img src="https://github.com/wyshmily/WpfPhotoFrame/blob/master/WpfPhotoFrame.Demo/Images/result2.png" width="400">
<img src="https://github.com/wyshmily/WpfPhotoFrame/blob/master/WpfPhotoFrame.Demo/Images/result3.png" width="400">

#### Usage:

##### PhotoFrame
````xaml

<!--xmlns:pf="http://wpf.wyshmily/photoframe"-->

<pf:PhotoFrame Source="Images/TestFrame.png" CornerSizes="60 60" Scale="0.4" Mode="Intermediate" VerticalAlignment="Center" HorizontalAlignment="Center">
    <Image Source="Images/jangye.jpeg" Width="400"/>
</pf:PhotoFrame>

````

#### NuGet Package:
`PM> Install-Package WpfPhotoFrame`
