using System;

using CrossPlatformLibrary.IoC;
using CrossPlatformLibrary.Messaging;

using Xamarin.Forms;

namespace MessagingSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ButtonSendMail(object sender, EventArgs e)
        {
            var emailTask = SimpleIoc.Default.GetInstance<IEmailTask>();
            //emailTask.SendEmail(new EmailMessage(
            //    to: "info@superdev.ch",
            //    subject: "Sent from CrossPlatformLibrary.Messaging",
            //    message: "This is a demo message."));
        }
    }
}