using Syncfusion.XForms.Chat;
using Syncfusion.XForms.PopupLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GettingStarted
{
    public class ImageMessageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<object> messages;
        SfPopupLayout popup;

        /// <summary>
        /// current user of chat.
        /// </summary>
        private Author currentUser;

        public ImageMessageViewModel()
        {
            this.messages = new ObservableCollection<object>();
            this.currentUser = new Author() { Name = "Nancy", Avatar = "People_Circle16.png" };
            this.GenerateMessages();
            Command = new Command(Tapped);
        }

        #region Command

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

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            popup.Dismiss();
        }

        #endregion

        #region Properties


        /// <summary>
        /// Gets or sets the group message conversation.
        /// </summary>
        public ObservableCollection<object> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }

        /// <summary>
        /// Gets or sets the current author.
        /// </summary>
        public Author CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }
        #endregion

        #region Messages Generation
        private void GenerateMessages()
        {
            this.Messages.Add(new ImageMessage()
            {
                Aspect = Xamarin.Forms.Aspect.AspectFill,
                Source = "Image1.jpg",
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
            });

            this.Messages.Add(new ImageMessage()
            {
                Aspect = Xamarin.Forms.Aspect.AspectFit,
                Source = "Image1.jpg",
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
            });

            this.Messages.Add(new ImageMessage()
            {
                Aspect = Xamarin.Forms.Aspect.Fill,
                Source = "Image1.jpg",
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
            });


            this.Messages.Add(new ImageMessage()
            {
                Aspect = Xamarin.Forms.Aspect.AspectFill,
                Source = "Image3.jpg",
                Author = this.CurrentUser,
            });

            this.Messages.Add(new ImageMessage()
            {
                Aspect = Xamarin.Forms.Aspect.Fill,
                Source = "Image3.jpg",
                Author = this.CurrentUser,
            });

            this.Messages.Add(new ImageMessage()
            {
                Aspect = Xamarin.Forms.Aspect.AspectFit,
                Source = "Image3.jpg",
                Author = this.CurrentUser,
            });


            this.Messages.Add(new ImageMessage()
            {
                Text = "Hi",
                Aspect = Xamarin.Forms.Aspect.AspectFill,
                Source = "Image1.jpg",
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
            });

            this.Messages.Add(new ImageMessage()
            {
                Text = "Hi",
                Aspect = Xamarin.Forms.Aspect.AspectFit,
                Source = "Image1.jpg",
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
            });

            this.Messages.Add(new ImageMessage()
            {
                Text = "Hi",
                Aspect = Xamarin.Forms.Aspect.Fill,
                Source = "Image1.jpg",
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
            });

            this.Messages.Add(new ImageMessage()
            {
                Text = "Hi",
                Aspect = Xamarin.Forms.Aspect.AspectFill,
                Source = "Image3.jpg",
                Author = this.CurrentUser,
            });

            this.Messages.Add(new ImageMessage()
            {
                Text = "Hi",
                Aspect = Xamarin.Forms.Aspect.AspectFit,
                Source = "Image3.jpg",
                Author = this.CurrentUser,
            });

            this.Messages.Add(new ImageMessage()
            {
                Text = "Hi",
                Aspect = Xamarin.Forms.Aspect.Fill,
                Source = "Image3.jpg",
                Author = this.CurrentUser,
            });
        }

        #endregion

        #region Property Changed

        /// <summary>
        /// Property changed handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when property is changed.
        /// </summary>
        /// <param name="propName">changed property name</param>
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion
    }
}
