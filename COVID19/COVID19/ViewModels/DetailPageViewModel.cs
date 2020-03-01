using COVID19.Models;
using Prism.Navigation;

namespace COVID19.ViewModels
{
    public class DetailPageViewModel : ViewModelBase, IInitialize
    {
        Countries country;
        public Countries Country { get => country; set { SetProperty(ref country, value); } }

        public DetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Country = new Countries();
        }

        public void Initialize(INavigationParameters parameters)
        {
            Country = parameters.GetValue<Countries>("country");
            Title = Country.CountryName;
        }

    }
}
