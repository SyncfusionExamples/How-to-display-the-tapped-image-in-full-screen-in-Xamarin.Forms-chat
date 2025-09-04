# How-to-display-the-tapped-image-in-full-screen-in-Xamarin.Forms-chat
This sample describes how to show an image in full screen when tapped on it in a Xamarin.Forms chat application using the ImageTapped event and ImageTappedCommand in SfChat. https://help.syncfusion.com/xamarin/chat/messages#event-and-command

## Sample

```xaml

        <sfchat:SfChat x:Name="sfChat" 
                       StickyTimeBreak="False"
                       MessageShape="DualTearDrop"
                       ShowOutgoingMessageAvatar="True"
                       ShowIncomingMessageAvatar="True"
                       Messages="{Binding Messages}"
                       ImageTappedCommand="{Binding Command}"
                       CurrentUser="{Binding CurrentUser}"
                       IncomingMessageTimestampFormat="hh:mm tt"
                       ShowAttachmentButton="True"
                       AttachmentButtonCommand="{Binding Command}"
                       AttachmentButtonCommandParameter="{x:Reference sfChat}"
                       OutgoingMessageTimestampFormat="hh:mm tt" >
        </sfchat:SfChat>

ViewModel:

        public ImageMessageViewModel()
        {
            ...
            Command = new Command(Tapped);
        }

        public ICommand Command
        {
            get;
            set;
        }

        private void Tapped(object args)
        {
            popup = new SfPopupLayout();
            popup.PopupView.ShowHeader = false;
            popup.PopupView.AnimationMode = AnimationMode.Zoom;

            DataTemplate bodyTemplateView = new DataTemplate(() =>
            {
                var imageView = new Image();
                imageView.BackgroundColor = Color.Black;
                imageView.Source = (args as ImageTappedEventArgs).Message.Source;
                imageView.Margin = new Thickness(0, 20, 0, 20);
                return imageView;
            });

            DataTemplate footerTemplateView = new DataTemplate(() =>
            {
                var backButton = new Button();
                backButton.Text = "Go back to chat";
                backButton.Clicked += BackButton_Clicked;
                return backButton;
            });

            popup.PopupView.ContentTemplate = bodyTemplateView;
            popup.PopupView.FooterTemplate = footerTemplateView;
            popup.Show(true);
        }
        
```

## Requirements to run the demo

To run the demo, refer to [System Requirements for Xamarin](https://help.syncfusion.com/xamarin/system-requirements).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

