using Playground.Content.LoadingScreen.UI;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class NopBackToMetaFromStageFlowUseCase : IBackToMetaFromStageFlowUseCase
    {
        public Task Execute(ILoadingToken loadingToken)
        {
            return Task.CompletedTask;
        }
    }
}
