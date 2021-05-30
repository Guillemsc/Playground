using Playground.Content.LoadingScreen.UI;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class NopLoadMetaFlowUseCase : ILoadMetaFlowUseCase
    {
        public Task Execute(ILoadingToken loadingToken)
        {
            return Task.CompletedTask;
        }
    }
}
