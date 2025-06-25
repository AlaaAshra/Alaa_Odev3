namespace Alaa_Odev3
{
    public partial class NewsDetailPage : ContentPage
    {
        private string currentUrl;

        public NewsDetailPage(string url)
        {
            InitializeComponent();
            currentUrl = url;
            webView.Source = url;
        }

        private async void ShareNews_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = currentUrl,
                Title = "Paylaş"
            });
        }
    }
}
