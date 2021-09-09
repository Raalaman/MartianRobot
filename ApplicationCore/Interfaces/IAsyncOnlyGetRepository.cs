using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public interface IAsyncOnlyGetRepository<T> 
    {
        Task<T> GetAllAsync();
    }

}
