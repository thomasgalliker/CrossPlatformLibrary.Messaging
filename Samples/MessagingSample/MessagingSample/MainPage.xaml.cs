using System;

using CrossPlatformLibrary.IoC;
using CrossPlatformLibrary.Messaging;

using Xamarin.Forms;

namespace MessagingSample
{
    public partial class MainPage : ContentPage
    {
        private readonly IEmailTask emailTask;
        private readonly ISmsTask smsTask;
        private readonly IPhoneCallTask phoneCallTask;

        public MainPage()
        {
            this.InitializeComponent();

            this.emailTask = SimpleIoc.Default.GetInstance<IEmailTask>();
            this.smsTask = SimpleIoc.Default.GetInstance<ISmsTask>();
            this.phoneCallTask = SimpleIoc.Default.GetInstance<IPhoneCallTask>();

            this.ButtonSendMail.IsEnabled = this.emailTask.CanSendEmail;
            this.ButtonSendSms.IsEnabled = this.smsTask.CanSendSms;
            this.ButtonPhoneCall.IsEnabled = this.phoneCallTask.CanMakePhoneCall;
        }

        private void OnButtonSendMailClicked(object sender, EventArgs e)
        {
            if (this.emailTask.CanSendEmail)
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
                this.emailTask.SendEmail(emailMessage);
            }
        }

        public bool SendAsHtml { get; set; }


        private void OnButtonSendSmsClicked(object sender, EventArgs e)
        {
            if (this.smsTask.CanSendSms)
            {
                this.smsTask.SendSms("+4179 111 22 33", "Well hello there from CrossPlatformLibrary.Messaging!");
            }
        }
        
        private void OnButtonPhoneCallClicked(object sender, EventArgs e)
        {
            if (this.phoneCallTask.CanMakePhoneCall)
            {
                this.phoneCallTask.MakePhoneCall("+4179 111 22 33", "Xamarin User");
            }
        }
    }
}