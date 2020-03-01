namespace COVID19.ViewModels
{
    using COVID19.Models;
    using COVID19.Models.Response;
    using COVID19.Services;
    using Prism.Navigation;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly ApiService apiService;

        bool isLoading = true;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                SetProperty(ref isLoading, value);
            }
        }

        ObservableCollection<Countries> countries;
        public ObservableCollection<Countries> Countries
        {
            get => countries;
            set
            {
                SetProperty(ref countries, value);
            }
        }

        Countries selectedCountry;
        public Countries SelectedCountry
        {
            get => selectedCountry;
            set
            {
                SetProperty(ref selectedCountry, value);
                if (selectedCountry!=null)
                    GoToDetail();

            }
        }

        private async void GoToDetail()
        {
            var parameters = new NavigationParameters{ { "country", SelectedCountry } };
            await navigationService.NavigateAsync("DetailPage", parameters);
        }

        public MainPageViewModel(INavigationService navigationService, ApiService apiService)
            : base(navigationService)
        {
            Title = "Infected Countries";
            this.navigationService = navigationService;
            this.apiService = apiService;
            Countries = new ObservableCollection<Countries>();
            LoadPage();
        }

        private async Task LoadPage()
        {
            try
            {
                var response = await apiService.Get<CountriesResponse>();
                foreach (var p in response.Countries)
                {
                    foreach (var q in p)
                    {
                        Countries.Add(new Countries { CountryName = q.Key.Replace("_"," "), DataCountry = q.Value });
                    }
                }
                await Task.Delay(2000);
                IsLoading =!IsLoading;
            }
            catch
            {
                return;
            }
        }

    }
}
