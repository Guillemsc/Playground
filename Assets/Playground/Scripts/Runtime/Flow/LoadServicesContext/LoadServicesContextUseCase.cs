using Playground.Contexts.Services;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.LoadServicesContext
{
    public class LoadServicesContextUseCase : ILoadServicesContextUseCase
    {
        public Task Execute()
        {
            return ServicesContextLoader.Load();
        }
    }
}
