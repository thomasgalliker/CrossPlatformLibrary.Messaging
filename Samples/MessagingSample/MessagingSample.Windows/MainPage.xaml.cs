namespace MessagingSample.Windows
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.LoadApplication(new MessagingSample.App());
        }
    }
}