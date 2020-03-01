using System.Threading.Tasks;
using Refit;

namespace COVID19.Services
{
    public class ApiService
    {
        public async Task<TResponse> Get<TResponse>()
        {
            var refitservice = RestService.For<ClientService<TResponse>>("https://covid2019-api.herokuapp.com/");

            return await refitservice.GetCountries();
        }
    }
}
