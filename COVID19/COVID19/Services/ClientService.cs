using System.Threading.Tasks;
using Refit;

namespace COVID19.Services
{
    public interface ClientService<ResponseModel>
    {
        [Get("/current_list")]
        Task<ResponseModel> GetCountries();
    }
}
