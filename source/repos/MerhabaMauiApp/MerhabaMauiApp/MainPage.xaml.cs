using static System.Net.Mime.MediaTypeNames;

< ContentPage xmlns = "http://schemas.microsoft.com/dotnet/2021/maui"
             x: Class = "MerhabaMauiApp.MainPage" >

    < VerticalStackLayout Padding = "30" >
        < Label Text = "Merhaba .NET MAUI!"
               FontSize = "32"
               HorizontalOptions = "Center" />
        < Button Text = "Tıkla"
                Clicked = "OnCounterClicked" />
    </ VerticalStackLayout >

</ ContentPage >