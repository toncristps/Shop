namespace Shop.UIForms
{
    using Shop.UIForms.ViewModels;
    using Shop.UIForms.Views;
    using Xamarin.Forms;
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainViewModel.GetInstance().Login = new LoginViewModel();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
