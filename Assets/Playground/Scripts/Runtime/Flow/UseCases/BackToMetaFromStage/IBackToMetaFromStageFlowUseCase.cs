using Playground.Content.LoadingScreen.UI;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public interface IBackToMetaFromStageFlowUseCase
    {
        Task Execute(ILoadingToken loadingToken);
    }
}
