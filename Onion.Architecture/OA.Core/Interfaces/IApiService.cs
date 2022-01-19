using System.Threading.Tasks;

namespace OA.Core.Interfaces
{
    public interface IApiService
    {
        Task<T> Get<T>(object items,string uri);
    }
}
