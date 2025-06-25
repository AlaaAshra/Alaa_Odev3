namespace Alaa_Odev3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public void NavigateToAppShell()
        {
            MainPage = new AppShell();
        }
    }
}



