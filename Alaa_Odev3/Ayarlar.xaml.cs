namespace Alaa_Odev3
{
    public partial class Ayarlar : ContentPage
    {
        public Ayarlar()
        {
            InitializeComponent();
            darkModeSwitch.IsToggled = Application.Current.UserAppTheme == AppTheme.Dark;
        }

        private void OnDarkModeToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Light;
            }
        }
    }
}
