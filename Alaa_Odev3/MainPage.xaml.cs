using Alaa_Odev3;
using System.Reflection;

namespace Alaa_Odev3
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void registerLogingPageView(object sender, EventArgs e)
        {
            if (registerStack.IsVisible)
            {
                registerStack.IsVisible = false;
                loginStack.IsVisible = true;
            }
            else
            {
                registerStack.IsVisible = true;
                loginStack.IsVisible = false;
            }

        }

        private async void loginClicked(object sender, EventArgs e)
        {
            //var data = HaberlerServices.Getnews("https://www.trthaber.com/manset_articles.rss");
            //await Console.Out.WriteLineAsync(data.Result);
            //return;

            var user = await Model.FirebaseServices.Login(txtEmail.Text, txtPass.Text);
            if (user != null)
            {

                await DisplayAlert($"Hoşgeldin! {user.Info.DisplayName}", "Giriş başarılı", "TAMAM");
                (Application.Current as App).NavigateToAppShell();


            }
            else
            {
                await DisplayAlert("Hata", "Giriş hatalı", "TAMAM");
            }
        }

        private async void registerClicked(object sender, EventArgs e)
        {

            var user = await Model.FirebaseServices.Register(RtxtName.Text, RtxtEmail.Text, RtxtPass.Text);
            if (user != null)
            {

                await DisplayAlert("Başarılı", "Kaydınız tamamlandı! Lütfen giriş yapın.", "Tamam");


                registerStack.IsVisible = false;
                loginStack.IsVisible = true;
            }
            else
            {

                await DisplayAlert("Hata", "Kayıt başarısız", "Tamam");
            }
        }




    }
}
