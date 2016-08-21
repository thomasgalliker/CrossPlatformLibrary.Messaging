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

            if (emailTask.CanSendEmail)
            {
                var builder =
                    new EmailMessageBuilder().To("to.plugins@xamarin.com")
                        .Cc("cc.plugins@xamarin.com")
                        .Bcc(new[] { "bcc1.plugins@xamarin.com", "bcc2.plugins@xamarin.com" })
                        .Subject("CrossPlatformLibrary.Messaging");

                if (this.SendAsHtml)
                {
                    builder.BodyAsHtml("Well hello there from <b>CrossPlatformLibrary.Messaging</b>");
                }

                if (!this.SendAsHtml)
                {
                    builder.Body("Well hello there from CrossPlatformLibrary.Messaging");
                }

                var emailMessage = builder.Build();
                emailTask.SendEmail(emailMessage);
            }
        }

        public bool SendAsHtml { get; set; }

        private void ButtonSendSms(object sender, EventArgs e)
        {
            var smsTask = SimpleIoc.Default.GetInstance<ISmsTask>();

            if (smsTask.CanSendSms)
            {
                smsTask.SendSms("+4179 111 22 33", "Well hello there from CrossPlatformLibrary.Messaging!");
            }
        }

        private void ButtonPhoneCall(object sender, EventArgs e)
        {
            var phoneCall = SimpleIoc.Default.GetInstance<IPhoneCallTask>();

            if (phoneCall.CanMakePhoneCall)
            {
                phoneCall.MakePhoneCall("+4179 111 22 33", "Xamarin User");
            }
        }
    }
}