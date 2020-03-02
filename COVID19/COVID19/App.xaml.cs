using Prism;
using Prism.Ioc;
using COVID19.ViewModels;
using COVID19.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using COVID19.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace COVID19
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#FFB300");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#fafafa");
            ((NavigationPage)Application.Current.MainPage).BackgroundColor = Color.FromHex("#424242");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailPage, DetailPageViewModel>();

            containerRegistry.RegisterSingleton<ApiService>();
        }
    }
}
