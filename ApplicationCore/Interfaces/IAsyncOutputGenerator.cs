using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public interface IAsyncOutputGenerator<T, U>
    {
        Task<List<U>> GenerateOutput(T inputData);
    }

}
