using Playground.Contexts.LoadingScreen;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.LoadLoadingScreenContext
{
    public class LoadLoadingScreenContextUseCase : ILoadLoadingScreenContextUseCase
    {
        public Task Execute()
        {
            return LoadingScreenContextLoader.Load();
        }
    }
}
